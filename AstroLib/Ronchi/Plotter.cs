using System;
using System.Collections.Generic;

namespace AstroLib.Ronchi
{
    public class Plotter
    {
        public Plotter(Random random)
        {
            Random = random;
        }

        private Random Random { get; set; }

        public Plotter():this (new Random())
        {
        }

        public List<XY> Generate(RonchiParms ronchiParms)
        {
            List<XY> Points = new List<XY>();
            double mirrorRadiusInches = ronchiParms.MirrorDiameterInches / 2;
            double RonchiLineWidthInches = 1 / (2 * ronchiParms.GratingLinesPerInch);

            for (int ray = 0; ray < ronchiParms.RaysToPlot; ray++)
            {
                double mirrorX = Random.NextDouble() * mirrorRadiusInches;
                double mirrorY = Random.NextDouble() * mirrorRadiusInches;
                double mirrorZone = Math.Sqrt(Math.Pow(mirrorX, 2) + Math.Pow(mirrorY, 2));
                if (mirrorZone <= mirrorRadiusInches)
                {
                    // for spherical mirror, Z=RC;
                    // correction factor for paraboloid is 1
                    double Z = ronchiParms.RCinches + ronchiParms.ParabolicCorrectionFactor * Math.Pow(mirrorZone, 2) / ronchiParms.RCinches;
                    // offset*2 for light source that moves with Ronchi grating 
                    double L = ronchiParms.RCinches + ronchiParms.GratingOffsetFromRCinches * 2 - Z;
                    // U = projection of ray at mirrorRadiusInches onto grating displaced from RC by gratingOffset 
                    double U = Math.Abs(L * mirrorX / Z);
                    // test for ray blockage by grating 
                    double T = (int)((U / RonchiLineWidthInches) + 0.5);
                    if (T / 2 == (int)T / 2)
                    {
                        double plotX = mirrorX / mirrorRadiusInches;
                        double plotY = mirrorY / mirrorRadiusInches;
                        // plot rays in each quadrant 
                        Points.Add(new XY(-plotX, -plotY));
                        Points.Add(new XY(-plotX, plotY));
                        Points.Add(new XY(plotX, -plotY));
                        Points.Add(new XY(plotX, plotY));
                    }
                }
            }
            return Points;
        }
    }
}
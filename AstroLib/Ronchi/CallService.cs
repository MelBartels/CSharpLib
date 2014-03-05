using System;
using System.Collections.Generic;

namespace AstroLib.Ronchi
{
    public class CallService
    {
        private readonly Plotter _pPlotter;

        public CallService()
        {
            _pPlotter = new Plotter();
        }

        public List<XY> GetPoints(StringParms stringParms)
        {
            RonchiParms ronchiParms = convert(stringParms);
            if (ronchiParms == null)
                return null;

            return _pPlotter.Generate(ronchiParms);
        }

        protected static RonchiParms convert(StringParms stringParms)
        {
            double dia;
            if (!Double.TryParse(stringParms.MirrorDiameterInches, out dia) || dia <= 0)
                return null;

            double RC;
            if (!Double.TryParse(stringParms.MirrorRCInches, out RC) || RC <= 0)
                return null;

            double grating;
            if (!Double.TryParse(stringParms.GratingLinesPerInch, out grating) || grating <= 0)
                return null;

            // no validation check for <0 because it's ok for offset to be negative
            double offset;
            if (!Double.TryParse(stringParms.OffsetInches, out offset))
                return null;

            double correction = 1;

            if (stringParms.Width <= 0 || stringParms.Height <= 0)
                return null;

            int rays;
            if (!Int32.TryParse(stringParms.Rays, out rays))
                return null;

            return new RonchiParms(dia, RC, grating, offset, correction, rays);
        }
    }
}
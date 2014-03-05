using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenLib.Extensions;

namespace AstroLib.ObjectLibrary.SAC
{
    // changes from documentation:
    // commented out 2nd "SL" catalog since all SL are dark nebulae
    // reordered a few entries that were out of alphabetical order
    // added:
    //   Danks
    //   Djorgovski
    //   FCC
    //   Fleming
    //   GCL, OCL (point to same catalog) (see http://www.ngcicproject.org/public_HCNGC/The_HCNGC_intro.pdf)
    //   I Zw, III Zw, IV Zw
    //   Longmore
    //   Peimbert
    //   Perek
    //   PGC 
    //   SAO
    //   Sh2

    public class Catalogs
    {
        public Dictionary<string, string> Lookup =
            new Dictionary<string, string>
                {
                    {"3C", "Third Cambridge Catalog of Radio Wave Sources"},
                    {"Abell", "George Abell (planetary nebulae and galaxy clusters"},
                    {"ADS", "Aitken Double Star catalog"},
                    {"AM", "Arp,Madore (globular clusters)"},
                    {"Antalova", "(open clusters)"},
                    {"Ap", "Apriamasvili (planetary nebulae)"},
                    {"Arp", "Halton Arp (interacting galaxies)"},
                    {"Bark", "Barkhatova (open clusters)"},
                    {"B", "Barnard (dark nebulae)"},
                    {"Basel", "(open clusters)"},
                    {"BD", "Bonner Durchmusterung (stars)"},
                    {"Berk", "Berkeley (open clusters)"},
                    {"Be", "Bernes (dark nebulae)"},
                    {"Biur", "Biurakan (open clusters)"},
                    {"Blanco", "(open clusters)"},
                    {"Bochum", "(open clusters)"},
                    {"Ced", "Cederblad (bright nebulae)"},
                    {"CGCG", "Catalog of Galaxies and Clusters of Galaxies)"},
                    {"Cr", "Collinder (open clusters)"},
                    {"Czernik", "(open clusters)"},
                    {"Danks", "(open clusters)"},
                    {"DDO", "David Dunlap Observatory (dwarf galaxies)"},
                    {"Djorgovski", ("globular clusters")},
                    {"Do", "Dolidze (open clusters)"},
                    {"DoDz", "Dolidze,Dzimselejsvili (open clusters)"},
                    {"Dun", "Dunlop (Southern objects of all types)"},
                    {"ESO", "European Southern Observatory (Southern objects)"},
                    {"Fein", "Feinstein (open clusters)"},
                    {"FCC", "A catalog of galaxies in the central 3.5 degs of the Fornax Cluster by H. C. Ferguson - 1989"},
                    {"Fleming", "(planetary nebulae)"},
                    {"Frolov", "(open clusters)"},
                    {"GCL", "Catalogue of Star Clusters and Associations by J. Ruprecht, B. Balazs, & R. E. White - 1981"},
                    {"Gum", "(bright nebulae)"},
                    {"H", "William Herschel (globular clusters)"},
                    {"Haffner", "(open clusters)"},
                    {"Harvard", "(open clusters)"},
                    {"Hav,Moffat", "Havermeyer and Moffat (open clusters)"},
                    {"He", "Henize (planetary nebulae)"},
                    {"Hogg", "(open clusters)"},
                    {"Ho", "Holmberg (galaxies)"},
                    {"HP", "Haute Provence (globular clusters)"},
                    {"Hu", "Humason (planetary nebulae)"},
                    {"I Zw", "Zwicky (galaxies)"},
                    {"III Zw", "Zwicky (galaxies)"},
                    {"IV Zw", "Zwicky (galaxies)"},
                    {"IC", "1st and 2nd Index Catalogs to the NGC (All types of objects except dark nebulae)"},
                    {"Isk", "Iskudarian (open clusters)"},
                    {"J", "Jonckheere (planetary nebulae)"},
                    {"K", "Kohoutek (planetary nebulae)"},
                    {"Kemble", "Father Lucian Kemble (asterisms)"},
                    {"King", "(open clusters)"},
                    {"Kr", "Krasnogorskaja (planetary nebulae)"},
                    {"Lac", "Lacaille (globular clusters)"},
                    {"LBN", "Lynds (bright nebula)"},
                    {"LDN", "Lynds (dark nebulae)"},
                    {"Loden", "(open clusters)"},
                    {"Longmore", "(planetary nebulae"},
                    {"Lynga", "(open clusters)"},
                    {"M", "Messier (all types of objects except dark nebulae)"},
                    {"MCG", "Morphological Catalog of Galaxies"},
                    {"Me", "Merrill (plantary nebulae)"},
                    {"Mrk", "Markarian (open clusters and galaxies)"},
                    {"Mel", "Melotte (open clusters)"},
                    {"M1", "Minkowski (planetary nebulae)"},
                    {"M2", "Minkowski (planetary nebulae)"},
                    {"M3", "Minkowski (planetary nebulae)"},
                    {"M4", "Minkowski (planetary nebulae)"},
                    {"New", "\"New\" galaxies in the Revised Shapley,Ames Catalog"},
                    {"NGC", "New General Catalog of Nebulae & Clusters (All types of objects except dark nebulae)"},
                    {"NPM1G", "Northern Proper Motion, 1st part, Galaxies"},
                    {"OCL", "Catalogue of Star Clusters and Associations by J. Ruprecht, B. Balazs, & R. E. White - 1981"},
                    {"Pal", "Palomar (globular clusters)"},
                    {"PB", "Peimbert and Batiz (planetary nebulae)"},
                    {"PC", "Peimbert and Costero (planetary nebulae)"},
                    {"Peimbert", "Planetary nebulae (Peimbert)"},
                    {"Perek", "Planetary nebulae (Perek)"},
                    {"PGC", "Principal Galaxies Catalog"},
                    {"Pismis", "(open clusters)"},
                    {"PK", "Perek & Kohoutek (planetary nebulae)"},
                    {"RCW", "Rodgers, Campbell, & Whiteoak (bright nebulae)"},
                    {"Roslund", "(open clusters)"},
                    {"Ru", "Ruprecht (open clusters)"},
                    {"Sa", "Sandqvist (dark nebulae)"},
                    {"SAO", "Smithsonian Astrophysical Observatory catalog"},
                    {"Sher", "(open clusters)"},
                    {"Sh", "Sharpless (bright nebulae)"},
                    {"Sh2", "A Catalogue of H II Regions by S. Sharpless - 1959"},
                    {"SL", "Sandqvist & Lindroos (dark nebulae)"},
                    //{"SL", "Shapley & Lindsay (clusters in LMC)"},                    
                    {"Steph", "Stephenson (open clusters)"},
                    {"Stock", "(open clusters)"},
                    {"Ter", "Terzan (globular clusters)"},
                    {"Tombaugh", "(open clusters)"},
                    {"Ton", "Tonantzintla (globular clusters)"},
                    {"Tr", "Trumpler (open clusters)"},
                    {"UGC", "Uppsala General Catalog (galaxies)"},
                    {"UGCA", "Uppsala General Catalog, Addendum (galaxies)"},
                    {"UKS", "United Kingdom Schmidt (globular clusters)"},
                    {"Upgren", "(open clusters)"},
                    {"V V", "Vorontsov,Velyaminov (interacting galaxies)"},
                    {"vdB", "van den Bergh (open clusters, bright nebulae)"},
                    {"vdBH", "van den Bergh & Herbst (bright nebulae)"},
                    {"vdB,Ha", "van den Bergh,Hagen (open clusters)"},
                    {"Vy", "Vyssotsky (planetary nebulae)"},
                    {"Waterloo", "(open clusters)"},
                    {"Winnecke", "Double Star (Messier 40)"},
                    {"ZwG", "Zwicky (galaxies)"},
                };

        public string GetFrom(string value)
        {
            var sb = new StringBuilder();
            value.Split(";".ToCharArray())
                .ForEach(v => Lookup
                                  .Where(c => v.Trim().StartsWith(c.Key))
                                  // best fit is longest fitting key
                                  .OrderByDescending(c => c.Key.Length)
                                  .FirstOrDefault()
                                  .Value
                                  .Do(c =>
                                          {
                                              if (!string.IsNullOrEmpty(c)) 
                                                  sb.Append(c + "; ");
                                          }));
            return sb.ToString().TrimEnd("; ".ToCharArray());
        }

        public bool CatalogFound(string value)
        {
            var found = false;
            value.Split(";".ToCharArray())
                .ForEach(v =>
                             {
                                 if (!found)
                                     found = Lookup.Any(c => v.Trim().StartsWith(c.Key));
                             });
            return found;
        }
    }
}
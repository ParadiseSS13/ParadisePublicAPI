using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database
{
    public partial class Character
    {
        public int Id { get; set; }
        public string Ckey { get; set; } = null!;
        public int Slot { get; set; }
        public string OocNotes { get; set; } = null!;
        public string RealName { get; set; } = null!;
        public bool NameIsAlwaysRandom { get; set; }
        public string Gender { get; set; } = null!;
        public short Age { get; set; }
        public string Species { get; set; } = null!;
        public string Language { get; set; } = null!;
        public string HairColour { get; set; } = null!;
        public string SecondaryHairColour { get; set; } = null!;
        public string FacialHairColour { get; set; } = null!;
        public string SecondaryFacialHairColour { get; set; } = null!;
        public short SkinTone { get; set; }
        public string SkinColour { get; set; } = null!;
        public string MarkingColours { get; set; } = null!;
        public string HeadAccessoryColour { get; set; } = null!;
        public string HairStyleName { get; set; } = null!;
        public string FacialStyleName { get; set; } = null!;
        public string MarkingStyles { get; set; } = null!;
        public string HeadAccessoryStyleName { get; set; } = null!;
        public string AltHeadName { get; set; } = null!;
        public string EyeColour { get; set; } = null!;
        public string Underwear { get; set; } = null!;
        public string Undershirt { get; set; } = null!;
        public string? Backbag { get; set; }
        public string BType { get; set; } = null!;
        public short AlternateOption { get; set; }
        public int JobSupportHigh { get; set; }
        public int JobSupportMed { get; set; }
        public int JobSupportLow { get; set; }
        public int JobMedsciHigh { get; set; }
        public int JobMedsciMed { get; set; }
        public int JobMedsciLow { get; set; }
        public int JobEngsecHigh { get; set; }
        public int JobEngsecMed { get; set; }
        public int JobEngsecLow { get; set; }
        public int JobKarmaHigh { get; set; }
        public int JobKarmaMed { get; set; }
        public int JobKarmaLow { get; set; }
        public string FlavorText { get; set; } = null!;
        public string MedRecord { get; set; } = null!;
        public string SecRecord { get; set; } = null!;
        public string GenRecord { get; set; } = null!;
        public int Disabilities { get; set; }
        public string PlayerAltTitles { get; set; } = null!;
        public string OrganData { get; set; } = null!;
        public string RlimbData { get; set; } = null!;
        public string NanotrasenRelation { get; set; } = null!;
        public int Speciesprefs { get; set; }
        public string Socks { get; set; } = null!;
        public string BodyAccessory { get; set; } = null!;
        public string Gear { get; set; } = null!;
        public bool Autohiss { get; set; }
        public string HairGradient { get; set; } = null!;
        public string HairGradientOffset { get; set; } = null!;
        public string HairGradientColour { get; set; } = null!;
        public byte HairGradientAlpha { get; set; }
    }
}

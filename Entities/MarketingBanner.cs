using System.ComponentModel.DataAnnotations;

namespace PanelsProject_Backend.Entities
{
    public class MarketingBanner
    {
        public int Id { get; set; }
        public string TitleEn { get; set; }
        public string AimEn { get; set; }
        [StringLength(1000)]
        public string DescriptionEn { get; set; }
        public string TitleRu { get; set; }
        public string AimRu { get; set; }
        [StringLength(1000)]
        public string DescriptionRu { get; set; }
        public string TitleKa { get; set; }
        public string AimKa { get; set; }
        [StringLength(1000)]
        public string DescriptionKa { get; set; }
        public string ImgUrl { get; set; }
    }
}


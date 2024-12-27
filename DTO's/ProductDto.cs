namespace PanelsProject_Backend.DTO_s
{
    public class ProductDto
    {
        public int MainProductSectionId { get; set; }  // ID of the MainProductSection the product belongs to

        // Translatable fields for the product
        public string TitleEn { get; set; }
        public string DescriptionEn { get; set; }
        public string ButtonTextEn { get; set; }
        public string BackgroundUrl { get; set; }  // Same background URL for all languages

        public string TitleKa { get; set; }
        public string DescriptionKa { get; set; }
        public string ButtonTextKa { get; set; }

        public string TitleRu { get; set; }
        public string DescriptionRu { get; set; }
        public string ButtonTextRu { get; set; }
    }

}

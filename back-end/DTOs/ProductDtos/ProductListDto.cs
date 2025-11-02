using back_end.DTOs.ProductNotesDTOs;
using back_end.Models;
using System.Text.Json.Serialization;


namespace back_end.DTOs.ProductDtos
{
    public class ProductListDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public int Reviews { get; set; }
        public Gender gender { get; set; }

        public ProductNotesListDto? Notes { get; set; }
    }
}
using back_end.Models;
using back_end.DTOs.ProductNotesDTOs;
namespace back_end.DTOs.ProductDtos;



public class ProductCreateDto

{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public Gender gender { get; set; }

    public ProductsNotesCreateDto? Notes { get; set; }

}


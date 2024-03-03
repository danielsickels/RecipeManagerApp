namespace RecipesApi.Models;

public class RecipeDTO
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Ingredients { get; set; }
    public string? Instructions { get; set; }
}
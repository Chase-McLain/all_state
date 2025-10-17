using System.ComponentModel.DataAnnotations;


namespace all_state.Models;


public class Recipe
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  [MinLength(1), MaxLength(255)] public string Title { get; set; }
  [MaxLength(5000)] public string Instructions { get; set; }
  [Url, MinLength(1), MaxLength(1000)] public string Img { get; set; }
  public string Category { get; set; }
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }
  public int FavoriteCount { get; set; }
}
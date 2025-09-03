namespace SQL_Exo.Models;

public class Utilisateur
{
    public int UserId { get; set; }
    public string Nom { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Bio { get; set; }

    // Relations
    public ICollection<Post> Posts { get; set; } = new List<Post>();
    public ICollection<Commentaire> Commentaires { get; set; } = new List<Commentaire>();
}

public class Post
{
    public int PostId { get; set; }
    public int UserId { get; set; }
    public string Contenu { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public DateTime DateCreation { get; set; }

    // Navigation properties (nullable car EF peut ne pas les charger)
    public Utilisateur? Utilisateur { get; set; }
    public ICollection<Commentaire> Commentaires { get; set; } = new List<Commentaire>();
}

public class Commentaire
{
    public int CommentaireId { get; set; }
    public int PostId { get; set; }
    public int UserId { get; set; }
    public string Contenu { get; set; } = string.Empty;
    public DateTime DateCreation { get; set; }

    // Navigation properties
    public Post? Post { get; set; }
    public Utilisateur? Utilisateur { get; set; }
}

namespace PremierProg;

public class Classe
{
    public Classe() {}
    public Classe(string nom_classe, List<Person> students, string niveau, string nom_ecole)
    {
        this.nom_classe = nom_classe;
        this.niveau = niveau;
        this.nom_ecole = nom_ecole;
        this.students = students;
        
    }

    private String nom_classe;
    private String nom_ecole;
    private String niveau;
    private List<Person> students;
    
    
    public string NomClasse
    {
        get => nom_classe;
        set => nom_classe = value ?? throw new ArgumentNullException(nameof(value));
    }

    public List<Person> Students
    {
        get => students;
        set => students = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Niveau
    {
        get => niveau;
        set => niveau = value ?? throw new ArgumentNullException(nameof(value));
    }

    
    
}
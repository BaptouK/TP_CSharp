namespace PremierProg;

public class Person
{
    public Person()
    {
    }

    public Person(string prenom, string nom, string birthday,Adresse adresse)
    {
        this.prenom = prenom;
        this.nom = nom;
        this.birthday = date_StringToDate(birthday);
        this.adresse = adresse;
    }

    private String prenom;
    private String nom;
    private DateTime birthday;

    private Adresse adresse;
    public int taille = 0;

    public Adresse Adresse
    {
        get => adresse;
        set => adresse = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    public DateTime Birthday
    {
        get => birthday;
        set => birthday = value;
    }
    
    public int getAgeYear()
    {
        DateTime aujourdhui = DateTime.Now;
        int age = DateTime.Now.Year - birthday.Year;

        if (aujourdhui.Month < birthday.Month || (aujourdhui.Month == birthday.Month && aujourdhui.Day < birthday.Day))
        {
            age --;
        }
        return age;
    }

    public void setPersonBirthday(string date)
    {
        DateTime date2 = date_StringToDate(date);
        this.birthday = date2;
    }
    public DateTime date_StringToDate(string date)
    {
        DateTime dateNaissance = DateTime.Parse(date);
        return dateNaissance;
    }
    
    
    public string Prenom
    {
        get => prenom;
        set => prenom = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Nom
    {
        get => nom;
        set => nom = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    public void displayInfo()
    {
        if (this.taille == 0) // Si la taille n'est pas renseignée
        {
            Console.WriteLine($"Bonjour, {this.prenom} {this.nom}," +
                              $"\ntu as { this.getAgeYear().ToString()} ans et tu habite au {this.adresse.Street} {this.adresse.ZipCode} {this.adresse.City}.");
        }
        else
        {
            Console.WriteLine($"Bonjour, {this.prenom} {this.nom}," +
                              $"\ntu as { this.getAgeYear().ToString()} ans, tu fait {this.taille}Cm et tu habite au {this.adresse.Street} {this.adresse.ZipCode} {this.adresse.City}.");
        }

    }
}
// See https://aka.ms/new-console-template for more information

using System.ComponentModel;
using Microsoft.VisualBasic;
using PremierProg;
using System.Globalization;
using System.Text;
using System.Threading;
//Pour avoir les date au format francais
Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");

#region Initialisation de la premiere personne

string prenom = "Baptiste";
string nom = "Dupuis";
string rue = "9 rue du swag";
int codePos = 44300;
string ville = "Nantes";
string birthday = "24/06/2006";

Adresse adresse1 = new Adresse(rue, codePos, ville);
Person person1 = new Person(prenom, nom, birthday,adresse1);
person1.setPersonBirthday("13/04/1975");

person1.displayInfo();
person1.displayInfo();

#endregion

List<Person> personnes = new List<Person>();

#region Ajout des personnes et affichage des infos

string file_path = "C:\\Users\\Baptiste.dps\\dev\\CoursCsharp\\PremierProg\\data.csv";
String line;
try{
    //Pass the file path and file name to the StreamReader constructor
    StreamReader sr = new StreamReader(file_path, Encoding.UTF8);
    
    //Read the first line of text
    //Passer le Header 
    line = sr.ReadLine();
    
    //Console.WriteLine(line);
    
    //Continue to read until you reach end of file
    while (line != null)
    {
        //Read the next line
        line = sr.ReadLine();
        //Console.WriteLine(line);
        
        // Gère les problèmes de ligne vide à la fin
        if (line == null) {
            break;
        }
        
        List<String> personParam = line.Split(",").ToList();
        List<String> adressParam = personParam[4].Split(";").ToList();
        
        Adresse ad = new Adresse(adressParam[0].Substring(1),int.Parse(adressParam[1]) ,adressParam[2]);
        
        Person p = new Person(personParam[2], personParam[1], personParam[3], ad);
        p.taille = int.Parse(personParam[5]);
        
        personnes.Add(p);
        //p.displayInfo();
    }
    sr.Close();
}
catch(Exception e){
    Console.WriteLine("Exception: " + e.Message);
}

#endregion

#region Calcul des moyennes et des personnes plus grandes que la moyenne

float moyenne = personnes.Average(personne => Convert.ToSingle(personne.taille));

List <Person> personnesPlusGrandMoyenne = personnes.Where(personne => personne.taille > moyenne).ToList();

Console.WriteLine($"La moyenne de la classe est {moyenne}cm. \n" +
                  $"Il y a {personnesPlusGrandMoyenne.Count} personnes plus grande que la moyenne");

#endregion

#region Création de la classe

Console.WriteLine("Quel est le nom de l'école ?");
String nom_ecole =Console.ReadLine();

Console.WriteLine("Quel est le nom de la classe ?");
String nom_classe = Console.ReadLine();

Console.WriteLine("Quel est le niveau de la classe ?");
String niveau_classe = Console.ReadLine();

Classe c1 = new Classe(nom_ecole, personnes, nom_classe,niveau_classe);

Console.WriteLine($"La classe {c1.NomClasse} de l'école {c1.NomClasse} de niveau {c1.Niveau} a {c1.Students.Count} élèves.");

#endregion


#region Quatrieme exercice : Afficher les personnes trié par les plus grandes de Nantes uniquement 

float moyenneTailleClasse = c1.Students.Average(personne => Convert.ToSingle(personne.taille));

List<Person> personnesNantaises = c1.Students.Where(personne => personne.Adresse.City == "Nantes").ToList();

List<Person> personnesNantaisesAuDessusMoyenne = personnesNantaises.Where(personne => personne.taille> moyenneTailleClasse ).ToList();

List<Person> personnesNantaisesTriees = personnesNantaisesAuDessusMoyenne.OrderByDescending(personne => personne.taille).ToList();

int compteur_taille = 1;
foreach (var personne in personnesNantaisesTriees)
{
    Console.WriteLine($"{compteur_taille} - {personne.Prenom} - {personne.taille/100f}m");
    compteur_taille++;
}

for (int cpt = 0; cpt<personnesNantaisesTriees.Count; cpt++)
{
}

#endregion


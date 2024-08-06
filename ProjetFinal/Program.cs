using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    //classe Etudiant
    public class Etudiant
    {
        //Proprietes
        public int NumeroEtudiant { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        //Contructeur
        public Etudiant(int numeroEtudiant, string nom, string prenom)
        {
            NumeroEtudiant = numeroEtudiant;
            Nom = nom;
            Prenom = prenom;
        }
        //Methode ToString
        public override string ToString()
        {
            return $"{NumeroEtudiant},{Nom},{Prenom}";
        }
    }
    //Classe Cours
    public class Cours
    {
        //Proprietes
        public int NumeroCours { get; set; }
        public string Code { get; set; }
        public string Titre { get; set; }
        //Constructeur
        public Cours(int numeroCours, string code, string titre)
        {
            NumeroCours = numeroCours;
            Code = code;
            Titre = titre;
        }
        //Methode ToString
        public override string ToString()
        {
            return $"{NumeroCours},{Code},{Titre}";
        }
    }
    //Classe Notes
    public class Notes
    {
        //Proprietes
        public int NumeroEtudiant { get; set; }
        public int NumeroCours { get; set; }
        public double Note { get; set; }
        //Constructeur
        public Notes(int numeroEtudiant, int numeroCours, double note)
        {
            NumeroEtudiant = numeroEtudiant;
            NumeroCours = numeroCours;
            Note = note;
        }
        //Methode ToString
        public override string ToString()
        {
            return $"{NumeroEtudiant},{NumeroCours},{Note}";
        }
    }

    internal class Program
    {
        // Listes pour stocker les Etudiants, Cours et Notes
        static List<Etudiant> etudiants = new List<Etudiant>();
        static List<Cours> cours = new List<Cours>();
        static List<Notes> notes = new List<Notes>();

        static void Main(string[] args)
        {
            while (true)
            {
                // Afficher la Fiche principal
                Console.WriteLine("Fiche etudiante:");
                Console.WriteLine("1-Ajouter un étudiant");
                Console.WriteLine("2-Ajout d'un cours");
                Console.WriteLine("3-Ajout d'une note");
                Console.WriteLine("4-Affichage du relevé de notes");
                Console.WriteLine("5-Quitter");
                Console.Write("Choisir une option: ");
                int choix = int.Parse(Console.ReadLine());
                // Quitter le programme
                if (choix == 5) break;
                // Execution de l'action correspondant au choix de l'utilisateur
                switch (choix)
                {
                    case 1: AjouterEtudiant(); break;
                    case 2: AjouterCours(); break;
                    case 3: AjouterNote(); break;
                    case 4: AfficherReleve(); break;
                    default: Console.WriteLine("Option invalide"); break;
                }
            }
        }
        // Methode pour ajouter un étudiant
        static void AjouterEtudiant()
        {
            Console.Write("Numéro d'étudiant: ");
            if (int.TryParse(Console.ReadLine(), out int numero))
            {
                Console.Write("Nom: ");
                string nom = Console.ReadLine();
                Console.Write("Prénom: ");
                string prenom = Console.ReadLine();

                var etudiant = new Etudiant(numero, nom, prenom);
                etudiants.Add(etudiant);
                SauvegarderEtudiant(etudiant);//Sauvegarder l'Etudiant dans un fichier
                Console.WriteLine("Étudiant ajouté.");
            }
            else
            {
                Console.WriteLine("Etudiant introuvable, Veuillez entrer un numéro valide.");
            }
        }
        // Methode pour ajouter un cours
        static void AjouterCours()
        {
            Console.Write("Numéro du cours: ");
            if (int.TryParse(Console.ReadLine(), out int numero))
            {
                Console.Write("Code: ");
                string code = Console.ReadLine();
                Console.Write("Titre: ");
                string titre = Console.ReadLine();

                cours.Add(new Cours(numero, code, titre));
                Console.WriteLine("Cours ajouté.");
            }
            else
            {
                Console.WriteLine("Cours introuvable, Veuillez entrer un numéro valide.");
            }
        }
        // Methode pour ajouter une note
        static void AjouterNote()
        {
            Console.Write("Numéro d'étudiant: ");
            if (!int.TryParse(Console.ReadLine(), out int numeroEtudiant)) return;
            Console.Write("Numéro du cours: ");
            if (!int.TryParse(Console.ReadLine(), out int numeroCours)) return;
            Console.Write("Note: ");
            if (!double.TryParse(Console.ReadLine(), out double note)) return;

            notes.Add(new Notes(numeroEtudiant, numeroCours, note));
            Console.WriteLine("Note ajoutée.");
        }
        // Methode pour afficher le relevé de notes d'un étudiant
        static void AfficherReleve()
        {
            Console.Write("Numéro d'étudiant: ");
            if (!int.TryParse(Console.ReadLine(), out int numeroEtudiant)) return;
            string cheminFichier = $"{numeroEtudiant}.txt";
            // Vérifier si le fichier de relevé de notes existe
            if (File.Exists(cheminFichier))
            {
                Console.WriteLine("Relevé de notes:");
                Console.WriteLine(File.ReadAllText(cheminFichier));
            }
            else
            {
                Console.WriteLine("Relevé de notes introuvable pour cet étudiant");
            }
        }
        // Methode pour sauvegarder les informations d'un Etudiant dans un fichier
        static void SauvegarderEtudiant(Etudiant etudiant)
        {
            File.WriteAllText($"{etudiant.NumeroEtudiant}.txt", etudiant.ToString());
        }
    }
}


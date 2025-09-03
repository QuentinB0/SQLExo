# Gestionnaire de Posts - Application ASP.NET Core MVC

## Description

Cette application est un gestionnaire de posts développé en ASP.NET Core MVC avec Entity Framework Core et SQLite. Elle permet de créer, consulter, modifier et supprimer des posts avec une interface moderne et intuitive.

## Fonctionnalités

- **Gestion CRUD complète des posts** : Créer, lire, modifier et supprimer
- **Interface moderne** : Design responsive avec Bootstrap 5 et FontAwesome
- **Validation complète** : Validation côté client et serveur
- **Base de données SQLite** : Stockage local des données
- **Navigation intuitive** : Menu de navigation clair et accessible

## Structure du projet

```
SQL Exo/
├── Controllers/
│   ├── HomeController.cs      # Contrôleur de la page d'accueil
│   └── PostController.cs      # Contrôleur de gestion des posts
├── Models/
│   ├── Post.cs               # Modèle de données Post
│   └── ErrorViewModel.cs     # Modèle d'erreur
├── Views/
│   ├── Home/
│   │   └── Index.cshtml      # Page d'accueil
│   ├── Post/
│   │   ├── Index.cshtml      # Liste des posts
│   │   ├── Create.cshtml     # Formulaire de création
│   │   ├── Details.cshtml    # Détails d'un post
│   │   └── Edit.cshtml       # Formulaire de modification
│   └── Shared/
│       └── _Layout.cshtml    # Layout principal
├── Data/
│   └── MonDbContext.cs       # Contexte Entity Framework
└── wwwroot/                  # Fichiers statiques (CSS, JS, images)
```

## Modèle de données

### Post
- **PostId** : Identifiant unique (clé primaire)
- **Titre** : Titre du post (obligatoire, max 100 caractères)
- **Contenu** : Contenu du post (obligatoire, max 500 caractères)
- **Auteur** : Nom de l'auteur (optionnel, max 50 caractères)
- **DateCreation** : Date et heure de création (automatique)

## Installation et configuration

### Prérequis
- .NET 9.0 SDK
- Visual Studio 2022 ou Visual Studio Code

### Étapes d'installation

1. **Cloner le projet**
   ```bash
   git clone [URL_DU_REPO]
   cd "SQL Exo"
   ```

2. **Restaurer les packages NuGet**
   ```bash
   dotnet restore
   ```

3. **Créer la base de données**
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

4. **Lancer l'application**
   ```bash
   dotnet run
   ```

5. **Accéder à l'application**
   Ouvrir un navigateur et aller à `https://localhost:5001` ou `http://localhost:5000`

## Utilisation

### Navigation
- **Accueil** : Page d'accueil avec présentation des fonctionnalités
- **Posts** : Liste de tous les posts existants
- **Nouveau Post** : Créer un nouveau post
- **Confidentialité** : Page de politique de confidentialité

### Gestion des posts
1. **Créer un post** : Cliquer sur "Nouveau Post" et remplir le formulaire
2. **Voir les posts** : Cliquer sur "Posts" pour voir la liste
3. **Modifier un post** : Cliquer sur "Modifier" dans la liste ou les détails
4. **Supprimer un post** : Cliquer sur "Supprimer" et confirmer

## Technologies utilisées

- **Backend** : ASP.NET Core 9.0 MVC
- **Base de données** : SQLite avec Entity Framework Core
- **Frontend** : Bootstrap 5, FontAwesome, JavaScript
- **Validation** : Data Annotations, Validation côté client
- **Gestion de version** : Git

## Développement

### Ajouter de nouvelles fonctionnalités
1. Créer le modèle dans le dossier `Models/`
2. Ajouter le contrôleur dans le dossier `Controllers/`
3. Créer les vues dans le dossier `Views/[NomController]/`
4. Mettre à jour la navigation dans `_Layout.cshtml`

### Modifier la base de données
1. Modifier le modèle
2. Créer une nouvelle migration : `dotnet ef migrations add [NomMigration]`
3. Appliquer la migration : `dotnet ef database update`

## Contribution

1. Fork le projet
2. Créer une branche pour votre fonctionnalité
3. Commiter vos changements
4. Pousser vers la branche
5. Ouvrir une Pull Request

## Licence

Ce projet est sous licence MIT. Voir le fichier LICENSE pour plus de détails.

## Support

Pour toute question ou problème, veuillez ouvrir une issue sur le repository GitHub.

---

**Développé avec ❤️ en ASP.NET Core MVC**


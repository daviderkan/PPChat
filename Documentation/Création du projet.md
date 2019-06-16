[TOC]

# Création du projet

## création d'un projet .NET Core Angular

```powershell
# à la racine de votre dépot 
dotnet new angular
```

## Mettre à jour d'Angular vers la dernière version

```
#Ouvrez votre terminal
#Rendez-vous dans <dossier_projet>\ClientApp
#Mettre à jour npm
npm install -g npm
#mettre à jour les packages, entre autre Angular
npm install -g npm-check-updates
ncu -u
#Mise à jour
	#Tout mettre à jour
npm install
	#Mettre à jour un élément spécifique
ng update XXX    (remplacer XXX par, par exemple, @angular/core)
```

## Installation de MongoDB

Allez sur le site officiel et téléchargez l'installateur.

Bien penser à installer Compas.

Une fois l'installation terminée, ajouter le dossier ``<dossier_MongoDB>\Server\<version_number>\bin``  dans PATH.

## Utilisation de MongoDB

Vous pouvez lancer Mongo en spécifiant le dossier ou vont se situer les données

```
mongod --dbpath <data_directory_path>
```

Par la suite, la commande ``mongo`` permet de lancer une shell

Voici quelques exemples de commande :

```
# If it doesn't already exist, a database named BookstoreDb is created. If the database does exist, its connection is opened for transactions.

use BookstoreDb

db.Books.insertMany([{'Name':'Design Patterns','Price':54.93,'Category':'Computers','Author':'Ralph Johnson'}, {'Name':'Clean Code','Price':43.15,'Category':'Computers','Author':'Robert C. Martin'}])

db.Books.find({}).pretty()
```

## Ajout du driver MongoDB au projet

Ouvrez votre projet visual studio et, dans Nuget, installer le paquet : ``MongoDB.Driver``





---

Références : 

[Create a web API with ASP.NET Core and MongoDB](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-2.2&tabs=visual-studio)
# Manuel Utilisateur du Système de Workflow

---

## Introduction

Ce système permet de **créer**, **configurer** et **exécuter** des workflows personnalisés.  
Un workflow est une suite d’étapes et de règles permettant d’automatiser des processus métiers.

---

## Fonctionnalités principales

1. **Création de Workflow**
   - Définir un nom pour le workflow.
   - Ajouter des paramètres personnalisés (nom interne, nom affiché, type).
   - Ajouter des étapes avec un ordre précis.
   - Pour chaque étape, ajouter des règles avec une clé (module) et une valeur.

2. **Exécution de Workflow**
   - Saisir les paramètres d’exécution (dates, nombre de jours disponibles).
   - Lancer l’exécution et suivre la progression étape par étape.
   - Visualiser le résultat final avec succès ou échec et les messages associés.

---

## Guide d’utilisation

### 1. Créer un nouveau workflow

- Naviguez vers la page **Créer un nouveau workflow**.
- Saisissez le nom du workflow.
- Cliquez sur **Ajouter un paramètre** pour définir les paramètres nécessaires.
- Pour chaque paramètre, indiquez le nom interne, le nom affiché et le type (texte, nombre, date, etc.).
- Cliquez sur **Ajouter une étape** pour ajouter des étapes au workflow.
- Pour chaque étape, saisissez le nom et l’ordre d’exécution.
- Ajoutez des règles à chaque étape avec les clés et valeurs correspondantes.
- Cliquez sur **Créer** pour sauvegarder le workflow.

---

### 2. Exécuter un workflow

- Allez à la page d’exécution d’un workflow en entrant son identifiant dans l’URL.
- Remplissez les champs de paramètres (date de début, date de fin, jours disponibles).
- Cliquez sur **Exécuter le workflow**.
- Suivez la progression des étapes affichées en temps réel.
- À la fin, consultez le résultat global et les détails par étape.
- En cas d’erreur, un message explicatif s’affichera.

---

## Messages d’erreur courants

- **Date de fin antérieure à la date de début**  
  Assurez-vous que la date de fin est postérieure ou égale à la date de début.

- **Nombre de jours disponible négatif ou invalide**  
  Saisissez un nombre entier positif ou nul.

- **Échec d’une étape**  
  Le workflow s’arrête et indique quelle étape a échoué avec une raison compréhensible.

---

## Conseils d’utilisation

- Toujours vérifier les paramètres avant d’exécuter un workflow.
- Utiliser des noms clairs pour les paramètres et les étapes afin de faciliter la maintenance.
- En cas d’erreur, consulter les messages pour comprendre la cause.

---

## Support et contact

Pour toute question ou problème, contactez l’équipe technique à :  
**support@example.com**

---

## Version du manuel

- Version 1.0  
- Date : 23 juillet 2025


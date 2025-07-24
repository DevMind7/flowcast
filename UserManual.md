# Manuel Utilisateur du Syst�me de Workflow

---

## Introduction

Ce syst�me permet de **cr�er**, **configurer** et **ex�cuter** des workflows personnalis�s.  
Un workflow est une suite d��tapes et de r�gles permettant d�automatiser des processus m�tiers.

---

## Fonctionnalit�s principales

1. **Cr�ation de Workflow**
   - D�finir un nom pour le workflow.
   - Ajouter des param�tres personnalis�s (nom interne, nom affich�, type).
   - Ajouter des �tapes avec un ordre pr�cis.
   - Pour chaque �tape, ajouter des r�gles avec une cl� (module) et une valeur.

2. **Ex�cution de Workflow**
   - Saisir les param�tres d�ex�cution (dates, nombre de jours disponibles).
   - Lancer l�ex�cution et suivre la progression �tape par �tape.
   - Visualiser le r�sultat final avec succ�s ou �chec et les messages associ�s.

---

## Guide d�utilisation

### 1. Cr�er un nouveau workflow

- Naviguez vers la page **Cr�er un nouveau workflow**.
- Saisissez le nom du workflow.
- Cliquez sur **Ajouter un param�tre** pour d�finir les param�tres n�cessaires.
- Pour chaque param�tre, indiquez le nom interne, le nom affich� et le type (texte, nombre, date, etc.).
- Cliquez sur **Ajouter une �tape** pour ajouter des �tapes au workflow.
- Pour chaque �tape, saisissez le nom et l�ordre d�ex�cution.
- Ajoutez des r�gles � chaque �tape avec les cl�s et valeurs correspondantes.
- Cliquez sur **Cr�er** pour sauvegarder le workflow.

---

### 2. Ex�cuter un workflow

- Allez � la page d�ex�cution d�un workflow en entrant son identifiant dans l�URL.
- Remplissez les champs de param�tres (date de d�but, date de fin, jours disponibles).
- Cliquez sur **Ex�cuter le workflow**.
- Suivez la progression des �tapes affich�es en temps r�el.
- � la fin, consultez le r�sultat global et les d�tails par �tape.
- En cas d�erreur, un message explicatif s�affichera.

---

## Messages d�erreur courants

- **Date de fin ant�rieure � la date de d�but**  
  Assurez-vous que la date de fin est post�rieure ou �gale � la date de d�but.

- **Nombre de jours disponible n�gatif ou invalide**  
  Saisissez un nombre entier positif ou nul.

- **�chec d�une �tape**  
  Le workflow s�arr�te et indique quelle �tape a �chou� avec une raison compr�hensible.

---

## Conseils d�utilisation

- Toujours v�rifier les param�tres avant d�ex�cuter un workflow.
- Utiliser des noms clairs pour les param�tres et les �tapes afin de faciliter la maintenance.
- En cas d�erreur, consulter les messages pour comprendre la cause.

---

## Support et contact

Pour toute question ou probl�me, contactez l��quipe technique � :  
**support@example.com**

---

## Version du manuel

- Version 1.0  
- Date : 23 juillet 2025


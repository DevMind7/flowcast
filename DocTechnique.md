# Documentation Technique - Projet Flowcast

---

## Table des Matières

1. [Introduction](#1-introduction)  
2. [Architecture Générale](#2-architecture-générale)  
3. [Description des Modules](#3-description-des-modules)  
4. [Flux Fonctionnel & Workflow](#4-flux-fonctionnel--workflow)  
5. [Technologies & Frameworks Utilisés](#5-technologies--frameworks-utilisés)  
6. [Gestion des Données & Persistence](#6-gestion-des-données--persistence)  
7. [Communication Inter-Couches](#7-communication-inter-couches)  
8. [Tests & Qualité](#8-tests--qualité)  
9. [Déploiement & Configuration](#9-déploiement--configuration)  
10. [Bonnes Pratiques](#10-bonnes-pratiques)  
11. [Évolutions Futures](#11-évolutions-futures)  
12. [Annexes](#12-annexes)

---

## 1. Introduction

Le projet **Flowcast** est une application développée avec **.NET 8** et **.NET Aspire** suivant les principes de la **Clean Architecture**.  
Il s'agit d'un moteur d'exécution de workflows métiers configurables, avec une interface utilisateur Blazor et une API REST.

L'objectif de cette documentation est de fournir une vision claire et exhaustive de l'architecture, du fonctionnement, et des composants du système.

---

## 2. Architecture Générale

Flowcast est organisé en couches selon la Clean Architecture, assurant une séparation claire des responsabilités :

flowcast.Web <-> flowcast.AppHost <-> flowcast.Application <-> flowcast.Domain <-> flowcast.Persistance
↕
flowcast.Api


| Couche               | Description                                             |
|----------------------|---------------------------------------------------------|
| **flowcast.Web**      | Interface utilisateur (Blazor Server)                   |
| **flowcast.AppHost**  | Orchestrateur principal, coordonne les appels           |
| **flowcast.Application** | Logique métier, services, implémentations d'interfaces |
| **flowcast.Domain**   | Entités métier, interfaces abstraites, règles de gestion |
| **flowcast.Persistance** | Gestion de la base de données avec EF Core             |
| **flowcast.Api**      | API REST et moteur d'exécution des workflows            |
| **flowcast.ServiceDefaults** | Services communs et configurations partagées          |
| **flowcast.Tests**    | Tests unitaires et d’intégration                         |

Cette organisation garantit :
- Indépendance des frameworks
- Testabilité améliorée
- Facilité d'évolution et maintenance

---

## 3. Description des projets

### 3.1 flowcast.Api

- Expose les **endpoints REST** via des contrôleurs.  
- Contient le **moteur d'exécution des workflows** (`moteurEngine`).  
- Reçoit les requêtes, valide et délègue aux services métier.

### 3.2 flowcast.AppHost

- Orchestrateur principal.  
- Coordonne la logique métier via des appels à `flowcast.Application`.  
- Gère le déroulement global des workflows.

### 3.3 flowcast.Domain

- Définit les **entités métier** (ex. `Workflow`, `StepResult`, `User`).  
- Contient les **interfaces** (ex. repositories, services).  
- Intègre les **règles métier fondamentales** et invariants.

### 3.4 flowcast.Application

- Implémente les interfaces du domaine.  
- Contient la logique métier et les règles métier complexes.  
- Implémente des patterns comme Repository, Service, Unit of Work.

### 3.5 flowcast.Persistance

- Implémente les repositories avec **Entity Framework Core**.  
- Définit le contexte de données (`DbContext`).  
- Gère les migrations et le mapping des entités.

### 3.6 flowcast.ServiceDefaults

- Fournit des services communs réutilisables (logging, validation).  
- Configuration et services utilitaires.

### 3.7 flowcast.Tests

- Contient les tests unitaires (xUnit, NUnit).  
- Tests d’intégration et mocks via Moq ou autres frameworks.

### 3.8 flowcast.Web

- Interface utilisateur **Blazor Server**.  
- Consomme l'API via `HttpApiClient`.  
- Affiche les formulaires, le suivi d'exécution des workflows.

---

## 4. Flux Fonctionnel & Workflow

### 4.1 Déroulement général

1. L'utilisateur lance un workflow depuis l'interface Blazor (`flowcast.Web`).  
2. L’`AppHost` reçoit la requête, valide et prépare les paramètres.  
3. Le moteur dans `flowcast.Api` exécute les étapes du workflow.  
4. Chaque étape invoque les services métiers dans `flowcast.Application`.  
5. Les données sont sauvegardées ou lues via `flowcast.Persistance`.  
6. Le résultat est retourné à l’UI avec un suivi en temps réel des étapes.

### 4.2 Gestion progressive des étapes

- L’exécution est simulée étape par étape avec un affichage dynamique.  
- En cas d’échec d’une étape, l’exécution s’arrête et un message d’erreur s’affiche.  
- Possibilité de relancer une nouvelle exécution.

---

## 5. Technologies & Frameworks Utilisés

- **.NET 8** : Framework principal.  
- **.NET Aspire** : Infrastructure d’architecture.  
- **Blazor Server** : Interface utilisateur.  
- **Entity Framework Core** : ORM pour accès à la base de données.  
- **xUnit/NUnit, Moq** : Frameworks de tests.  
- **ASP.NET Core Web API** : Exposition des services REST.  
- **Dependency Injection (DI)** : Injection des dépendances dans toutes les couches.

---

## 6. Gestion des Données & Persistence

- Base de données relationnelle (SQL Server ou autre compatible EF Core).  
- Le contexte `DbContext` est défini dans `flowcast.Persistance`.  
- Migrations EF Core gèrent les évolutions du schéma.  
- Accès aux données via repositories abstraits dans `flowcast.Domain` et implémentés dans `flowcast.Application`.

---

## 7. Communication Inter-Couches

- Utilisation de **DTO** pour isoler la couche UI et API du modèle domaine.  
- Les entités du domaine ne sont jamais exposées directement à l’extérieur.  
- Les appels inter-couches respectent les interfaces pour découpler les modules.  
- Les exceptions sont gérées et traduites en messages utilisateur via un système de mapping.

---

## 8. Tests & Qualité

- Couverture unitaire élevée sur les services métiers et modules critiques.  
- Tests d’intégration validant les workflows complets.  
- CI/CD intégrée pour lancer les tests automatiquement.  
- Utilisation de mocks pour isoler les tests.

---

## 9. Déploiement & Configuration

- Déploiement de l’API sur un serveur IIS ou Azure App Service.  
- Blazor Server hébergé sur le même serveur ou séparément.  
- Configuration via `appsettings.json` et variables d’environnement.  
- Migrations EF Core exécutées lors du déploiement.

---

## 10. Bonnes Pratiques

- Validation stricte des données en entrée.  
- Logging complet et gestion d’erreurs centralisée.  
- Respect des principes SOLID et Clean Code.  
- Découplage via interfaces et DI.  
- Tests automatiques avant chaque déploiement.

---

## 11. Évolutions Futures

- Ajout d’une interface d’administration des workflows.  
- Notifications par email et webhooks.  
- Historique complet et audit des exécutions.  
- Amélioration des performances et scalabilité (ex: CQRS).  
- Internationalisation et support multilingue.

---

## 12. Annexes

### 12.1 Exemple de diagramme d’architecture

*À insérer selon outils utilisés (Visio, PlantUML, etc.)*

### 12.2 Glossaire

- **Workflow** : Suite d’étapes métiers à exécuter.  
- **StepResult** : Résultat d’une étape du workflow.  
- **DTO** : Data Transfer Object, objet de transfert entre couches.  
- **DI** : Dependency Injection, injection de dépendances.

---

> _Document généré pour le projet Flowcast – version initiale – .NET 8 / .NET Aspire_

---


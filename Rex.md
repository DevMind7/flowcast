# Fiche de Retour d’Expérience (REX)

---

## 1. Informations Générales

- **Nom du projet / workflow :** Gestion des demandes de congés  
- **Date de l’exécution :** 2025-07-22  
- **Utilisateur / Équipe :** Équipe RH

---

## 2. Objectifs

Automatiser le traitement des demandes de congés avec validation selon les règles métier, afin de réduire le temps de traitement manuel et minimiser les erreurs.

---

## 3. Déroulement

- Lancement du workflow via l’interface utilisateur.  
- Saisie des paramètres : dates de début et fin, nombre de jours disponibles.  
- Validation progressive des étapes : vérification solde de congés, contrôle de la durée maximale, approbation automatique.  
- Suivi de l’exécution en temps réel grâce à l’affichage des étapes.  

---

## 4. Résultats obtenus

- Résultats attendus : traitement rapide et conforme des demandes.  
- Résultats obtenus : 95% des demandes traitées sans intervention humaine, avec un retour immédiat aux utilisateurs.  
- Écarts : quelques demandes rejetées à tort à cause d’un bug sur la gestion des jours disponibles.

---

## 5. Difficultés rencontrées

- Confusion dans la gestion des jours disponibles suite à une mauvaise initialisation des paramètres.  
- Quelques erreurs techniques lors de la communication avec l’API backend.  
- Interface utilisateur manquant d’indications sur les raisons précises des refus.

---

## 6. Solutions apportées / Actions correctives

- Correction du calcul des jours disponibles dans la couche service.  
- Ajout d’une gestion des erreurs plus robuste avec affichage des messages user-friendly.  
- Mise à jour de l’interface pour mieux expliquer les refus de demandes.

---

## 7. Améliorations proposées

- Ajouter un historique des demandes pour consultation par l’utilisateur.  
- Implémenter une fonctionnalité de notification par email.  
- Permettre la modification d’une demande refusée après correction.

---

## 8. Enseignements

- Importance de valider rigoureusement les paramètres d’entrée.  
- Nécessité d’une communication claire avec l’utilisateur final.  
- L’exécution progressive améliore la compréhension du processus.

---

## 9. Conclusion

Le workflow automatisé a significativement amélioré la gestion des congés, réduisant la charge administrative. Les ajustements apportés ont renforcé la fiabilité et l’ergonomie du système. Des évolutions futures sont envisagées pour enrichir les fonctionnalités.

---



*Fin de la fiche de retour d’expérience*

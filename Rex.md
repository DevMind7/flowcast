# Fiche de Retour d�Exp�rience (REX)

---

## 1. Informations G�n�rales

- **Nom du projet / workflow :** Gestion des demandes de cong�s  
- **Date de l�ex�cution :** 2025-07-22  
- **Utilisateur / �quipe :** �quipe RH

---

## 2. Objectifs

Automatiser le traitement des demandes de cong�s avec validation selon les r�gles m�tier, afin de r�duire le temps de traitement manuel et minimiser les erreurs.

---

## 3. D�roulement

- Lancement du workflow via l�interface utilisateur.  
- Saisie des param�tres : dates de d�but et fin, nombre de jours disponibles.  
- Validation progressive des �tapes : v�rification solde de cong�s, contr�le de la dur�e maximale, approbation automatique.  
- Suivi de l�ex�cution en temps r�el gr�ce � l�affichage des �tapes.  

---

## 4. R�sultats obtenus

- R�sultats attendus : traitement rapide et conforme des demandes.  
- R�sultats obtenus : 95% des demandes trait�es sans intervention humaine, avec un retour imm�diat aux utilisateurs.  
- �carts : quelques demandes rejet�es � tort � cause d�un bug sur la gestion des jours disponibles.

---

## 5. Difficult�s rencontr�es

- Confusion dans la gestion des jours disponibles suite � une mauvaise initialisation des param�tres.  
- Quelques erreurs techniques lors de la communication avec l�API backend.  
- Interface utilisateur manquant d�indications sur les raisons pr�cises des refus.

---

## 6. Solutions apport�es / Actions correctives

- Correction du calcul des jours disponibles dans la couche service.  
- Ajout d�une gestion des erreurs plus robuste avec affichage des messages user-friendly.  
- Mise � jour de l�interface pour mieux expliquer les refus de demandes.

---

## 7. Am�liorations propos�es

- Ajouter un historique des demandes pour consultation par l�utilisateur.  
- Impl�menter une fonctionnalit� de notification par email.  
- Permettre la modification d�une demande refus�e apr�s correction.

---

## 8. Enseignements

- Importance de valider rigoureusement les param�tres d�entr�e.  
- N�cessit� d�une communication claire avec l�utilisateur final.  
- L�ex�cution progressive am�liore la compr�hension du processus.

---

## 9. Conclusion

Le workflow automatis� a significativement am�lior� la gestion des cong�s, r�duisant la charge administrative. Les ajustements apport�s ont renforc� la fiabilit� et l�ergonomie du syst�me. Des �volutions futures sont envisag�es pour enrichir les fonctionnalit�s.

---



*Fin de la fiche de retour d�exp�rience*

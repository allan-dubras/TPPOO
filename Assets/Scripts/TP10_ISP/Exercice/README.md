# TP10 - Interface Segregation Principle (ISP)

Ce projet illustre les problèmes associés à l'utilisation d'interfaces monolithiques et comment appliquer le principe de ségrégation des interfaces.

## Problème initial

- L'interface `IGameCharacter` est trop volumineuse
- Elle force les classes à implémenter des méthodes dont elles n'ont pas besoin
- De nombreuses méthodes lèvent des exceptions `NotImplementedException`
- L'ajout de nouvelles fonctionnalités affecte toutes les classes

## Exercice

L'objectif est de refactoriser le code en découpant l'interface monolithique `IGameCharacter` en interfaces plus petites et plus cohésives.

1. Divisez l'interface en groupes fonctionnels (mouvement, combat, interaction, etc.)
2. Faites en sorte que chaque classe n'implémente que les interfaces dont elle a réellement besoin
3. Éliminez les implémentations qui lèvent des exceptions
4. Assurez-vous que le système reste extensible

## Structure suggérée

Organisez vos interfaces en dossiers:
- Interfaces/Base (interfaces fondamentales)
- Interfaces/Movement (capacités de mouvement)
- Interfaces/Combat (capacités de combat)
- Interfaces/Interaction (capacités d'interaction)
- Interfaces/NPC (comportements des PNJ)

## Tests

Un programme de démonstration vous permettra de tester que toutes les entités conservent leurs fonctionnalités tout en n'implémentant que ce dont elles ont besoin.
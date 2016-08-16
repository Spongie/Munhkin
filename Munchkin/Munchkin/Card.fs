namespace Munchkin

module DomainTypes =

    type TurnState = FightingMonster | LootOrSummonMonster

    type TODO_FIX = unit

    type ItemCard = {
        Name : string
        Description : string
        }

    type CurseCard = {
        Name : string
        Description : string
    }
    
    and MonsterCard = {
            Name : string
            Description : string
            Level : int
            MinimumPlayerLevel : int
            LevelReward : int
            TreasureCount : int
            }
    
    and DoorCard = 
        | MonsterCard of MonsterCard 
        | CurseCard of CurseCard

    and TreasureCard =
        | ItemCard of ItemCard

    and GameState = {
        TurnState : TurnState
        CurrentPlayer : Player
        Players : Player list
        DoorCards : DoorCard list
        DiscardedDoorCards : DoorCard list
        MonstersFighting : MonsterCard list
        }
    
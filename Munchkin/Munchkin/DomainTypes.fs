namespace Munchkin

module DomainTypes =

    type TurnState = FightingMonster | LootOrSummonMonster

    type ItemCard = {
        Name : string
        Description : string
        Bonus : int
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

    and ClassCard = {
        Name : string
    }

    and RaceCard = {
        Name : string
    }
    
    and DoorCard = 
        | MonsterCard of MonsterCard 
        | CurseCard of CurseCard
        | ClassCard of ClassCard
        | RaceCard of RaceCard

    and TreasureCard =
        | ItemCard of ItemCard

    and Card =
        | TreasureCard of TreasureCard
        | DoorCard of DoorCard

    and Player = {
        Level : int
        Cards : Card list
        Equipped : ItemCard list
    }

    and Battle = {
        MonsterBuffs : DoorCard list
        PlayerBuffs : DoorCard list
        MonstersFighting : MonsterCard list
    }

    and GameState = {
        TurnState : TurnState
        CurrentPlayer : Player
        Players : Player list
        DoorCards : DoorCard list
        DiscardedDoorCards : DoorCard list
        CurrentBattle : Battle
    }
    
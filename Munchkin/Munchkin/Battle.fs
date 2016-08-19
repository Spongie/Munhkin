namespace Munchkin

open DomainTypes

module Battle =
    
    let createBattle monster =
        { MonstersFighting = [monster]; PlayerBuffs = []; MonsterBuffs = [] }


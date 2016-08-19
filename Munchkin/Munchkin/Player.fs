namespace Munchkin

open DomainTypes

module Player =

    let getPlayerLevel player =
        player.Equipped
        |>List.map (fun x -> x.Bonus)
        |>List.sum
        



module App

open Elmish
open Elmish.React
open Feliz

type Model =
    { SelectedCategory: Category option
      SelectedProducts: Product list }

type Msg =
    | SelectCategory of Category option

let init () =
    { SelectedCategory = None
      SelectedProducts = config.Products }

let update msg model =
    match msg with
    | SelectCategory category ->
        { model with
            SelectedCategory = category
            SelectedProducts =
                match category with
                | None -> config.Products
                | Some category ->
                    config.Products
                    |> List.filter (fun p -> p.Categories |> List.contains category)
        }

let allCategories =
    [ for p in config.Products do yield! p.Categories ]
    |> Set.ofList

let view model dispatch =
    let header = Html.header [
        Html.div [
            prop.className "container"
            prop.children [
                Html.a [
                    Html.img [ prop.src "images/logo.png"; prop.title config.SiteName ]
                ]
                Html.div [
                    prop.className "right-stuff"
                    prop.children [
                        Html.div [
                            Html.a [
                                prop.href $"https://m.me/{config.FacebookMessenger}"
                                prop.target "blank"
                                prop.children [
                                    Html.i [ prop.classes [ "fab"; "fa-lg"; "fa-facebook-messenger" ] ]
                                    Html.text " Messenger"
                                ]
                            ]
                        ]
                        Html.div [
                            Html.a [
                                prop.href $"tel:{config.PhoneNumber}"
                                prop.children [
                                    Html.i [ prop.classes [ "fas"; "fa-lg"; "fa-phone" ] ]
                                    Html.text $" {config.PhoneNumber}"
                                ]
                            ]
                            Html.a [
                                prop.href $"https://zalo.me/{config.PhoneNumber}"
                                prop.target "blank"
                                prop.text " | Zalo"
                            ]
                        ]
                    ]
                ]
            ]
        ]
    ]

    let collage = Html.section [
        Html.div [
            prop.className "collage"
            prop.style [
                style.backgroundImage "url(images/collage.jpg)"
            ]
            prop.children [
                Html.div [
                    prop.className "collage-overlay"
                    prop.children [
                        Html.div [
                            prop.className "collage-overlay-text"
                            prop.children [
                                Html.h1 config.WelcomeText
                                Html.p [ Html.strong config.SiteDescription ]
                            ]
                        ]
                    ]
                ]
            ]
        ]
    ]

    let renderProduct (product: Product) = Html.div [
        prop.classes [ "product"; "grid-item" ]
        prop.children [
            Html.img [ prop.src $"images/{product.Image}" ]
            Html.div [
                prop.className "card-content"
                prop.children [
                    Html.div [
                        prop.className "product-titlebar"
                        prop.children [
                            Html.h3 product.Name
                            Html.div [
                                prop.className "product-price"
                                prop.children [ Html.strong $"{product.Price} / {product.Unit}" ]
                            ]
                        ]
                    ]
                    Html.p [
                        
                        prop.text product.Description
                    ]
                ]
            ]
        ]
    ]

    let catalog = Html.section [
        Html.h2 "Danh mục sản phẩm"
        Html.div [
            prop.classes [ "category-wrapper"; "container" ]
            prop.children [
                Html.a [
                    prop.className (if model.SelectedCategory = None then "btn-selected" else "btn")
                    prop.text "Tất cả"
                    prop.href "javascript:void(0)"
                    prop.onClick (fun _ -> dispatch <| SelectCategory None)
                ]
                for category in allCategories do
                    Html.a [
                        prop.className (if model.SelectedCategory = Some category then "btn-selected" else "btn")
                        prop.text (string category)
                        prop.href "javascript:void(0)"
                        prop.onClick (fun _ -> dispatch <| SelectCategory (Some category))
                    ]
            ]
        ]
        Html.div [
            prop.className "container"
            prop.children [
                Html.div [
                    prop.classes [ "products"; "flex-grid" ]
                    prop.children [
                        for product in model.SelectedProducts do renderProduct product
                    ]
                ]
            ]
        ]
    ]

    let footer = Html.footer [
        Html.p config.FooterText
    ]

    Html.div [
        header
        Html.main [
            collage
            catalog
        ]
        footer
    ]

Program.mkSimple init update view
|> Program.withReactSynchronous "app"
|> Program.run

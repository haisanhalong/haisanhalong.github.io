module App

type Model =
    { SelectedCategory: Category option
      SelectedProducts: Product list }

type Msg =
    | SelectCategory of Category option

let init () =
    { SelectedCategory = None
      SelectedProducts = config.Products }

let update msg _ =
    match msg with
    | SelectCategory category ->
        {   SelectedCategory = category
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

open Sutil
open Sutil.CoreElements

let view () =
    let model, dispatch = Store.makeElmishSimple init update ignore ()

    let header = Html.header [
        Html.div [
            Attr.className "container"
            Html.a [
                Html.img [
                    Attr.src "images/logo.png"
                    Attr.title config.SiteName
                ]
            ]
            Html.div [
                prop.className "right-stuff"
                Html.div [
                    Html.a [
                        Attr.href $"https://m.me/{config.FacebookMessenger}"
                        Attr.target "blank"
                        Html.i [ Attr.classes [ "fab"; "fa-lg"; "fa-facebook-messenger" ] ]
                        Html.text " Messenger"
                    ]
                ]
                Html.div [
                    Html.a [
                        Attr.href $"tel:{config.PhoneNumber}"
                        Html.i [ Attr.classes [ "fas"; "fa-lg"; "fa-phone" ] ]
                        Html.text $" {config.PhoneNumber}"
                    ]
                    Html.a [
                        Attr.href $"https://zalo.me/{config.PhoneNumber}"
                        Attr.target "_blank"
                        Html.text " | Zalo"
                    ]
                ]
            ]
        ]
    ]

    let collage = Html.section [
        Html.div [
            Attr.className "collage"
            Attr.style [
                Css.backgroundImageUrl "images/collage.jpg"
                Css.backgroundRepeatRepeatX
            ]
            Html.div [
                Attr.className "collage-overlay"
                Html.div [
                    Attr.className "collage-overlay-text"
                    Html.h1 config.WelcomeText
                    Html.p [ Html.strong config.SiteDescription ]
                ]
            ]
        ]
    ]

    let renderProduct (product: Product) = Html.div [
        Attr.classes [ "product"; "grid-item" ]
        Html.img [
            Attr.src $"images/{product.Image}"
            Attr.alt "product image"
        ]
        Html.div [
            Attr.className "card-content"
            Html.div [
                Attr.className "product-titlebar"
                Html.h3 product.Name
                Html.div [
                    Attr.className "product-price"
                    Html.strong $"{product.Price} / {product.Unit}"
                ]
            ]
            Html.p product.Description
        ]
    ]

    let products = Html.section [
        Html.h2 "Danh mục sản phẩm"
        Html.div [
            Attr.classes [ "category-wrapper"; "container" ]
            Html.a [
                Attr.className "btn"
                Bind.toggleClass (model .> (fun m -> m.SelectedCategory = None), "selected")
                Attr.text "Tất cả"
                Ev.onClick (fun _ -> dispatch (SelectCategory None))
            ]
            for category in allCategories do
                Html.a [
                    Attr.className "btn"
                    Bind.toggleClass (model .> (fun m -> m.SelectedCategory = Some category), "selected")
                    Attr.text (string category)
                    Ev.onClick (fun _ -> dispatch (SelectCategory (Some category)))
                ]
        ]
        Html.div [
            Attr.className "container"
            Html.div [
                Attr.classes [ "products"; "flex-grid" ]
                Bind.each (model .> _.SelectedProducts, renderProduct)
            ]
        ]
    ]

    let renderReview (review: Review) = Html.figure [
        Attr.classes [ "review"; "grid-item" ]
        Html.img [
            Attr.src $"images/{review.Image}"
            Attr.alt "review image"
        ]
        Html.figcaption [
            Html.blockquote [ Html.p review.Content ]
            Html.h3 review.Author
        ]
    ]

    let reviews = Html.section [
        Html.h2 "Khách hàng đánh giá"
        Html.div [
            Attr.className "container"
            Html.div [
                Attr.classes [ "reviews"; "flex-grid" ]
                yield! (config.Reviews |> List.map renderReview)
            ]
        ]
    ]

    let footer = Html.footer [
        Html.p config.FooterText
    ]

    Html.div [
        disposeOnUnmount [ model ]
        header
        Html.main [
            collage
            products
            reviews
        ]
        footer
    ]

Program.mount ("app", view())
|> ignore

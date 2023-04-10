[<AutoOpen>]
module Config

type Unit =
    | Kg
    | NuaKg
    | Cai
    | Con
    | HopNuaKg
    | Khay10Cuon
    | KhayNuaKg
    | BichNuaKg
    override this.ToString () =
        match this with
        | Kg -> "kg"
        | NuaKg -> "500gr"
        | Cai -> "cái"
        | Con -> "con"
        | HopNuaKg -> "hộp 500gr"
        | Khay10Cuon -> "khay 10 cuốn"
        | KhayNuaKg -> "khay 500gr"
        | BichNuaKg -> "bịch 500gr"

type Category =
    | Ca
    | Tom
    | Muc
    | Ghe
    | Other
    override this.ToString () =
        match this with
        | Ca -> "Cá"
        | Tom -> "Tôm"
        | Muc -> "Mực"
        | Ghe -> "Ghẹ"
        | Other -> "Khác"

type Product =
    { Name: string
      Description: string
      Price: string
      Unit: Unit
      Image: string
      Categories: Category list }

type Config =
    { SiteName: string
      SiteDescription: string
      FacebookMessenger: string
      PhoneNumber: string
      WelcomeText: string
      CollageImage: string
      Products: Product list
      FooterText: string }

let config =
    { SiteName = "Hải Sản Hạ Long"
      SiteDescription = "Chúng tôi chuyên phục vụ các mặt hàng hải sản chất lượng."
      FacebookMessenger = "chiepepper0310"
      PhoneNumber = "0987918796"
      WelcomeText = "Hải Sản Hạ Long xin kính chào quý khách!"
      CollageImage = "collage.jpg"
      Products = [
          { Name = "Chả mực"
            Description = "Chả mực Hạ Long giã tay."
            Price = "250,000đ"
            Unit = NuaKg
            Image = "00-cha-muc.jpg"
            Categories = [ Muc ]
          }
          { Name = "Chả mực VIP"
            Description = "Chả mực VIP Hạ Long giã tay."
            Price = "300,000đ"
            Unit = NuaKg
            Image = "00-cha-muc-vip.jpg"
            Categories = [ Muc ]
          }
          { Name = "Chả cá"
            Description = "Chả có cả tôm và mực, đóng gói 500gr hoặc 1kg tuỳ theo yêu cầu."
            Price = "240,000đ"
            Unit = Kg
            Image = "01-cha-ca.jpg"
            Categories = [ Ca; Tom; Muc ]
          }
          { Name = "Chả tôm quấn sả"
            Description = "Chiên bằng nồi chiên không dầu rất ngon và tiện lợi."
            Price = "115,000đ"
            Unit = HopNuaKg
            Image = "02-cha-tom-quan-sa.jpg"
            Categories = [ Tom  ]
          }
          { Name = "Chả giò hải sản"
            Description = "Nhân ghẹ, tôm sắt, tôm tích, và thịt. Siêu ngon, tiện lợi, chỉ cần chiên đến khi vàng giòn."
            Price = "150,000đ"
            Unit = Khay10Cuon
            Image = "03-cha-gio-hai-san.jpg"
            Categories = [ Tom; Ghe ]
          }
          { Name = "Tôm sắt bóc nõn"
            Description = "Là loại tôm nhỏ, đã bóc vỏ và xào chín. Có thể rim nước mắm, rim cùng với thịt, hoặc băm nhỏ để nấu canh hoặc làm chả giò."
            Price = "130,000đ"
            Unit = KhayNuaKg
            Image = "04-tom-sat.jpg"
            Categories = [ Tom ]
          }
          { Name = "Mắm tép"
            Description = "Gồm tôm, thịt, mắm tép. Chế biến tiện lợi, chỉ cần hâm nóng là ăn được. Ăn với cơm hoặc bánh mì đều hợp."
            Price = "200,000đ"
            Unit = HopNuaKg
            Image = "05-mam-tep.jpg"
            Categories = [ Tom ]
          }
          { Name = "Cá chỉ vàng"
            Description = "Nướng làm mồi nhậu hoặc rang chua ngọt ăn cơm."
            Price = "120,000đ"
            Unit = BichNuaKg
            Image = "06-ca-chi-vang.jpg"
            Categories = [ Ca ]
          }
          { Name = "Mực ống"
            Description = "Thân tròn, mình mỏng, hơi dài như hình ống. Một trong những loại mực có hương vị và thịt thơm ngon nhất."
            Price = "210,000đ"
            Unit = KhayNuaKg
            Image = "07-muc-ong-ngon.jpg"
            Categories = [ Muc ]
          }
          { Name = "Cá măng một nắng"
            Description = "Được phơi dưới cái nắng vàng óng đủ vừa cho hương vị cá thơm ngon, ngọt dai."
            Price = "130,000đ"
            Unit = KhayNuaKg
            Image = "08-ca-mang-mot-nang.jpg"
            Categories = [ Ca ]
          }
          { Name = "Cá thu một nắng"
            Description = "Loại cá thu tươi đã được làm sạch đem phơi qua một nắng để giúp thịt cá săn chắc và ngọt hơn khi ăn."
            Price = "170,000đ"
            Unit = KhayNuaKg
            Image = "09-ca-thu-mot-nang.jpg"
            Categories = [ Ca ]
          }
          { Name = "Ghẹ bóc nõn"
            Description = "Phần thịt được tách bỏ từ phần thân và phần càng của ghẹ biển. Loại hải sản cao cấp, thơm ngon được nhiều người yêu thích."
            Price = "300,000đ"
            Unit = KhayNuaKg
            Image = "10-ghe-boc-non.jpg"
            Categories = [ Ghe ]
          }
          { Name = "Tôm tích bóc nõn"
            Description = "Được chọn lọc từ những con tôm tích còn tươi sống, hấp chín bỏ vỏ, lấy phần thịt. Thịt tôm chắc và dai ngọt, phù hợp chế biến nhiều món ăn ngon."
            Price = "215,000đ"
            Unit = KhayNuaKg
            Image = "11-tom-tich-boc-non.jpg"
            Categories = [ Tom ]
          }
          { Name = "Khô mực"
            Description = "(*) Loại nhỏ: 1,180,000đ/kg (18-20 con). Loại vừa: 1,300,000đ/kg (12-15 con). Loại to: 1,400,000đ/kg (6-7 con)."
            Price = "(*)đ"
            Unit = Kg
            Image = "12-kho-muc.jpg"
            Categories = [ Muc ]
          }
          { Name = "Sá sùng"
            Description = "Loại hải sản quý giá, thành phần dưỡng chất dồi dào, tốt cho sức khỏe."
            Price = "Giá liên hệ"
            Unit = Kg
            Image = "13-sa-sung.jpg"
            Categories = [ Other ]
          }
          { Name = "Cá đù một nắng"
            Description = "Dẻo thịt, vị mặn tự nhiên, dễ ăn, dễ chế biến chấm tương rất ngon."
            Price = "100,000đ"
            Unit = NuaKg
            Image = "14-ca-du-mot-nang.jpg"
            Categories = [ Ca ]
          }
      ]
      FooterText = "© Copyright 2023 Hải Sản Hạ Long"
    }

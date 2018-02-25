import { Observable } from "rxjs/Rx";
import { Product } from "./";
import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";

@Injectable()
export class ProductService {
    private readonly path = "/api/v1/products";
    private products = [
        {
            "productId": "55a73e85fea4ad03077606f7",
            "name": "Biltong (1kg)",
            "description": "Great taste award winning 2014",
            "detailedDescription":
                "Our biltong is made from fine matured local beef, marinated in our own blend of spices and vinegar to produce a wonderful, tasty snack which is protein packed and low in calories. It is available in a variety of flavours including traditional, chilli, garlic and oak smoked. You can specify whether you require your biltong wet or dry and we will tailor make it to suit, then deliver it to you as soon as it’s ready. So call us and place your order now for your biltong made by the meat experts.",
            "imageId": "55fd2d7d0a85b0ff7af2d191",
            "alt": "",
            "price": { "minor": 0, "major": 38 },
            "variationId": "55a73e85fea4ad03077606f8",
            "weight": { "unit": "kg", "value": 1 },
            "categories": ["Beef", "South African"],
            "isSpeciality": true,
            "pricePerKilo": { "major": 38, "minor": 0 }
        },
        {
            "productId": "55fd2d2f0a85b0ff7af2d133",
            "name": "Packington free range Chicken Leg (1kg)",
            "description": "Packington free range Chicken",
            "imageId": "55eed971672ed712a1b5502b",
            "alt": "",
            "price": { "major": 6, "minor": 60 },
            "variationId": "55fd2d2f0a85b0ff7af2d134",
            "weight": { "value": 1, "unit": "kg" },
            "categories": ["Chicken"],
            "pricePerKilo": { "major": 6, "minor": 60 }
        },
        {
            "productId": "55fd2d2f0a85b0ff7af2d13e",
            "name": "Homemade Honey and Mustard Sausages (500g)",
            "description": "Pack of 6. Homemade sausages made fresh in store.",
            "imageId": "55eed97e672ed712a1b55030",
            "alt": "",
            "price": { "minor": 49, "major": 4 },
            "variationId": "55fd2d2f0a85b0ff7af2d13f",
            "weight": { "unit": "g", "value": 500 },
            "categories": ["Pork"],
            "pricePerKilo": { "major": 8, "minor": 98 }
        },
        {
            "productId": "55fd2d2f0a85b0ff7af2d148",
            "name": "Leicestershire long horn Rump Steak (500g)",
            "description": "New Dry-Aged Himalayan Salt Wall Rump Steak",
            "imageId": "55eed9d6672ed712a1b5504a",
            "alt": "",
            "price": { "major": 9, "minor": 50 },
            "variationId": "55fd2d2f0a85b0ff7af2d149",
            "weight": { "value": 500, "unit": "g" },
            "categories": ["Beef"],
            "pricePerKilo": { "major": 19, "minor": 0 }
        },
        {
            "productId": "55fd2d2f0a85b0ff7af2d13a",
            "name": "Homemade Traditional Sausages (500g)",
            "description": "Pack of 6. Homemade sausages made fresh in store.",
            "imageId": "55eed985672ed712a1b55032",
            "alt": "",
            "price": { "minor": 99, "major": 3 },
            "variationId": "55fd2d2f0a85b0ff7af2d13b",
            "weight": { "unit": "g", "value": 500 },
            "categories": ["Pork"],
            "pricePerKilo": { "major": 7, "minor": 98 }
        },
        {
            "productId": "55fd2d2f0a85b0ff7af2d135",
            "name": "Packington free range Chicken Breast with skin (1kg)",
            "description": "Packington free range Chicken",
            "imageId": "55eed96f672ed712a1b5502a",
            "alt": "",
            "price": { "minor": 99, "major": 13 },
            "variationId": "55fd2d2f0a85b0ff7af2d136",
            "weight": { "unit": "kg", "value": 1 },
            "categories": ["Chicken"],
            "pricePerKilo": { "major": 13, "minor": 99 }
        },
        {
            "productId": "55fd3e1b0a85b0ff7af2d19e",
            "name": "Droëwors (1kg)",
            "description": "A flavoursome bite",
            "detailedDescription":
                "Made from scratch to an authentic South African recipe , a blend of coriander,clove and chuck beef with some secret spices. a tasty alternative to biltong .",
            "imageId": "563bc1d0d5e0edaf8a5e5bf8",
            "price": { "major": 32, "minor": 0 },
            "variationId": "55fd3e2c0a85b0ff7af2d19f",
            "weight": { "unit": "kg", "value": 1 },
            "categories": ["Beef", "South African"],
            "isSpeciality": true,
            "pricePerKilo": { "major": 32, "minor": 0 }
        },
        {
            "productId": "55fd52d20a85b0ff7af2d202",
            "name": "Packington free range Bacon Smoked (1kg)",
            "description": "Packington free range Bacon Smoked",
            "imageId": "5630dd64c8a7b8879a095a1c",
            "price": { "major": 15, "minor": 99 },
            "variationId": "55fd53020a85b0ff7af2d204",
            "weight": { "unit": "kg", "value": 1 },
            "categories": ["Pork"],
            "pricePerKilo": { "major": 15, "minor": 99 }
        },
        {
            "productId": "55fd52de0a85b0ff7af2d203",
            "name": "Packington free range Bacon Plain (1kg)",
            "description": "Packington free range Bacon Plain",
            "imageId": "5630dd7ec8a7b8879a095a1d",
            "price": { "major": 14, "minor": 99 },
            "variationId": "55fd530e0a85b0ff7af2d205",
            "weight": { "unit": "kg", "value": 1 },
            "categories": ["Pork"],
            "pricePerKilo": { "major": 14, "minor": 99 }
        },
        {
            "productId": "55fd53740a85b0ff7af2d206",
            "name": "Leicestershire long horn beef brisket (1kg)",
            "description": "Leicestershire Beef Brisket",
            "imageId": "55fd53a20a85b0ff7af2d207",
            "price": { "minor": 99, "major": 8 },
            "variationId": "55fd53c30a85b0ff7af2d208",
            "weight": { "value": 1, "unit": "kg" },
            "categories": ["Beef"],
            "pricePerKilo": { "major": 8, "minor": 99 }
        },
        {
            "productId": "55fd53ed0a85b0ff7af2d209",
            "name": "Leicestershire long horn (2.5kg)",
            "description": "Dry aged Rib of Beef",
            "imageId": "55eed9a0672ed712a1b55039",
            "price": { "minor": 47, "major": 38 },
            "variationId": "55fd54310a85b0ff7af2d20a",
            "weight": { "value": 2.5, "unit": "kg" },
            "categories": ["Beef"],
            "pricePerKilo": { "major": 15, "minor": 38 }
        },
        {
            "productId": "55fd54960a85b0ff7af2d20b",
            "name": "South Leicestershire Venison Noisettes (180g)",
            "description": "Individual Noisettes",
            "imageId": "55eed991672ed712a1b55033",
            "price": { "major": 4, "minor": 50 },
            "variationId": "55fd54a60a85b0ff7af2d20c",
            "weight": { "unit": "g", "value": 180 },
            "categories": ["Game"],
            "pricePerKilo": { "major": 25, "minor": 0 }
        },
        {
            "productId": "5648b9f21629541c11f1aba8",
            "name": "Diced Venison (500g)",
            "description": "ideal for stewing",
            "imageId": "5648babd1629541c11f1abaa",
            "price": { "major": 6, "minor": 50 },
            "variationId": "5648ba301629541c11f1aba9",
            "weight": { "unit": "g", "value": 500 },
            "categories": [null, "Game"],
            "pricePerKilo": { "major": 13, "minor": 0 }
        },
        {
            "productId": "55fd2d2f0a85b0ff7af2d144",
            "name": "Homemade Gluten Free Sausages (500g)",
            "description": "Pack of 6. Homemade sausages made fresh in store.",
            "imageId": "55eed977672ed712a1b5502d",
            "alt": "",
            "price": { "minor": 49, "major": 4 },
            "variationId": "55fd2d2f0a85b0ff7af2d145",
            "weight": { "unit": "g", "value": 500 },
            "categories": ["Pork"],
            "pricePerKilo": { "major": 8, "minor": 98 }
        },
        {
            "productId": "55fd2d2f0a85b0ff7af2d130",
            "name": "Packington free range Chicken Whole (1.9kg)",
            "description": "Packington free range Chicken",
            "imageId": "55fd2ee90a85b0ff7af2d192",
            "alt": "",
            "price": { "minor": 99, "major": 12 },
            "variationId": "55fd2d2f0a85b0ff7af2d132",
            "weight": { "unit": "kg", "value": 1.9 },
            "categories": ["Chicken"],
            "pricePerKilo": { "major": 6, "minor": 83 }
        },
        {
            "productId": "55fd2d2f0a85b0ff7af2d130",
            "name": "Packington free range Chicken Whole (2.4kg)",
            "description": "Packington free range Chicken",
            "imageId": "55fd2ee90a85b0ff7af2d192",
            "alt": "",
            "price": { "minor": 20, "major": 16 },
            "variationId": "55fd2d2f0a85b0ff7af2d131",
            "weight": { "unit": "kg", "value": 2.4 },
            "categories": ["Chicken"],
            "pricePerKilo": { "major": 6, "minor": 75 }
        },
        {
            "productId": "55fd2d2f0a85b0ff7af2d13c",
            "name": "Homemade Cumberland Sausages (500g)",
            "description": "Pack of 6. Homemade sausages made fresh in store.",
            "imageId": "55eed979672ed712a1b5502e",
            "alt": "",
            "price": { "minor": 49, "major": 4 },
            "variationId": "55fd2d2f0a85b0ff7af2d13d",
            "weight": { "unit": "g", "value": 500 },
            "categories": ["Pork"],
            "pricePerKilo": { "major": 8, "minor": 98 }
        },
        {
            "productId": "55fd2d2f0a85b0ff7af2d146",
            "name": "Leicestershire long horn Sirloin Steak (500g)",
            "description": "New Dry-Aged Himalayan Salt Wall Sirloin Steak",
            "imageId": "55fd2f600a85b0ff7af2d193",
            "alt": "",
            "price": { "major": 12, "minor": 50 },
            "variationId": "55fd2d2f0a85b0ff7af2d147",
            "weight": { "value": 500, "unit": "g" },
            "categories": ["Beef"],
            "pricePerKilo": { "major": 25, "minor": 0 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d150",
            "name": "Leicestershire long horn Côte de boeuf (1kg)",
            "description": "For 2 to share",
            "imageId": "55eed9af672ed712a1b5503f",
            "alt": "",
            "price": { "minor": 99, "major": 14 },
            "variationId": "55fd2d300a85b0ff7af2d151",
            "weight": { "unit": "kg", "value": 1 },
            "categories": ["Beef"],
            "pricePerKilo": { "major": 14, "minor": 99 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d14e",
            "name": "Leicestershire long horn  T-Bone Steak (500g)",
            "description": "A real dry aged carnivores delight",
            "imageId": "55eed9e5672ed712a1b55050",
            "alt": "",
            "price": { "major": 10, "minor": 0 },
            "variationId": "55fd2d300a85b0ff7af2d14f",
            "weight": { "value": 500, "unit": "g" },
            "categories": ["Beef"],
            "pricePerKilo": { "major": 20, "minor": 0 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d15a",
            "name": "Leicestershire long horn topside (1kg)",
            "description": "The traditional family roast joint",
            "imageId": "55fd31620a85b0ff7af2d19a",
            "alt": "",
            "price": { "major": 13, "minor": 99 },
            "variationId": "55fd2d300a85b0ff7af2d15b",
            "weight": { "value": 1, "unit": "kg" },
            "categories": ["Beef"],
            "pricePerKilo": { "major": 13, "minor": 99 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d158",
            "name": "Leicestershire long horn Braising Steak (1kg)",
            "description": "Braising steak slow cooked winter warmer",
            "imageId": "55eed9ad672ed712a1b5503e",
            "alt": "",
            "price": { "major": 10, "minor": 99 },
            "variationId": "55fd2d300a85b0ff7af2d159",
            "weight": { "value": 1, "unit": "kg" },
            "categories": ["Beef"],
            "pricePerKilo": { "major": 10, "minor": 99 }
        },
        {
            "productId": "55fd2d2f0a85b0ff7af2d140",
            "name": "Homemade Toulouse Sausages (500g)",
            "description": "Pack of 6. Homemade sausages made fresh in store.",
            "imageId": "55eed983672ed712a1b55031",
            "alt": "",
            "price": { "minor": 99, "major": 6 },
            "variationId": "55fd2d2f0a85b0ff7af2d141",
            "weight": { "unit": "g", "value": 500 },
            "categories": ["Pork"],
            "pricePerKilo": { "major": 13, "minor": 98 }
        },
        {
            "productId": "55fd2d2f0a85b0ff7af2d137",
            "name": "English Chicken Fillets (1kg)",
            "description": "",
            "imageId": "55eed96a672ed712a1b55029",
            "alt": "",
            "price": { "minor": 99, "major": 8 },
            "variationId": "55fd2d2f0a85b0ff7af2d139",
            "weight": { "unit": "kg", "value": 1 },
            "categories": ["Chicken", "Bulk"],
            "pricePerKilo": { "major": 8, "minor": 99 }
        },
        {
            "productId": "55fd2d2f0a85b0ff7af2d137",
            "name": "English Chicken Fillets (5kg)",
            "description": "",
            "imageId": "55fd2fdc0a85b0ff7af2d195",
            "alt": "",
            "price": { "minor": 95, "major": 24 },
            "variationId": "55fd2d2f0a85b0ff7af2d138",
            "weight": { "unit": "kg", "value": 5 },
            "categories": ["Chicken", "Bulk"],
            "pricePerKilo": { "major": 4, "minor": 99 }
        },
        {
            "productId": "55fd2d2f0a85b0ff7af2d14a",
            "name": "Leicestershire long horn Rib Eye Steak (500g)",
            "description": "dry aged well marbled steak",
            "imageId": "55fd30060a85b0ff7af2d196",
            "alt": "",
            "price": { "major": 14, "minor": 0 },
            "variationId": "55fd2d2f0a85b0ff7af2d14b",
            "weight": { "value": 500, "unit": "g" },
            "categories": ["Beef"],
            "pricePerKilo": { "major": 28, "minor": 0 }
        },
        {
            "productId": "55fd2d2f0a85b0ff7af2d142",
            "name": "Homemade Mergeuz Sausages (500g)",
            "description": "Pack of 8. Homemade sausages made fresh in store.",
            "imageId": "55fd302d0a85b0ff7af2d197",
            "alt": "",
            "price": { "minor": 99, "major": 6 },
            "variationId": "55fd2d2f0a85b0ff7af2d143",
            "weight": { "unit": "g", "value": 500 },
            "categories": ["Beef", "Lamb"],
            "pricePerKilo": { "major": 13, "minor": 98 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d154",
            "name": "Leicesterhire long horn Stewing Beef (1kg)",
            "description": "Ideal in a casserole",
            "imageId": "55fd305f0a85b0ff7af2d198",
            "alt": "",
            "price": { "major": 9, "minor": 99 },
            "variationId": "55fd2d300a85b0ff7af2d155",
            "weight": { "value": 1, "unit": "kg" },
            "categories": ["Beef"],
            "pricePerKilo": { "major": 9, "minor": 99 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d152",
            "name": "Leicestershire long horn Minced Beef (1kg)",
            "description": "Makes a tasty chilli!",
            "imageId": "55eed9c6672ed712a1b55047",
            "alt": "",
            "price": { "major": 8, "minor": 50 },
            "variationId": "55fd2d300a85b0ff7af2d153",
            "weight": { "value": 1, "unit": "kg" },
            "categories": ["Beef", "Bulk"],
            "pricePerKilo": { "major": 8, "minor": 50 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d152",
            "name": "Leicestershire long horn Minced Beef (5kg)",
            "description": "Makes a tasty chilli!",
            "imageId": "55eed9cf672ed712a1b55048",
            "price": { "major": 29, "minor": 0 },
            "variationId": "55fd309b0a85b0ff7af2d199",
            "weight": { "unit": "kg", "value": 5 },
            "categories": ["Beef", "Bulk"],
            "pricePerKilo": { "major": 5, "minor": 80 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d14c",
            "name": "Leicestershire long horn aged fillet Steak (500g)",
            "description": "tenderness on a plate",
            "detailedDescription": "Whole",
            "imageId": "55eed9b2672ed712a1b55040",
            "alt": "",
            "price": { "minor": 50, "major": 19 },
            "variationId": "55fd2d300a85b0ff7af2d14d",
            "weight": { "unit": "g", "value": 500 },
            "categories": ["Beef"],
            "pricePerKilo": { "major": 39, "minor": 0 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d14c",
            "name": "Leicestershire long horn aged fillet Steak (1kg)",
            "description": "tenderness on a plate",
            "detailedDescription": "Whole",
            "imageId": "55eed9ab672ed712a1b5503d",
            "price": { "major": 39, "minor": 0 },
            "variationId": "568d26d0cb2cdec77d234658",
            "weight": { "unit": "kg", "value": 1 },
            "categories": ["Beef"],
            "pricePerKilo": { "major": 39, "minor": 0 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d156",
            "name": "Leicestershire long horn Shin of Beef (1kg)",
            "description": "Time for the slow cooker",
            "imageId": "55eed9d8672ed712a1b5504b",
            "alt": "",
            "price": { "minor": 99, "major": 7 },
            "variationId": "55fd2d300a85b0ff7af2d157",
            "weight": { "unit": "kg", "value": 1 },
            "categories": ["Beef"],
            "pricePerKilo": { "major": 7, "minor": 99 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d15c",
            "name": "Leicestershire long horn rolled Sirloin (1kg)",
            "description": "King of the roasts",
            "imageId": "55fd2fa60a85b0ff7af2d194",
            "alt": "",
            "price": { "major": 24, "minor": 99 },
            "variationId": "55fd2d300a85b0ff7af2d15d",
            "weight": { "value": 1, "unit": "kg" },
            "categories": ["Beef"],
            "pricePerKilo": { "major": 24, "minor": 99 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d160",
            "name": "South Leicestershire Lamb Leg (Half)",
            "description": "South Leicestershire Lamb",
            "imageId": "5648b6eb1629541c11f1aba6",
            "alt": "",
            "price": { "minor": 99, "major": 12 },
            "variationId": "55fd2d300a85b0ff7af2d162",
            "weight": { "unit": "kg", "value": 1.3 },
            "categories": ["Lamb"],
            "pricePerKilo": { "major": 9, "minor": 99 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d160",
            "name": "South Leicestershire Lamb Leg (Whole)",
            "description": "South Leicestershire Lamb",
            "imageId": "55eed9bf672ed712a1b55044",
            "alt": "",
            "price": { "major": 28, "minor": 0 },
            "variationId": "55fd2d300a85b0ff7af2d161",
            "weight": { "value": 2.6, "unit": "kg" },
            "categories": ["Lamb"],
            "pricePerKilo": { "major": 10, "minor": 76 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d163",
            "name": "South Leicestershire Lamb Shoulder (Half)",
            "description": "South Leicestershire Lamb",
            "imageId": "55eed9c1672ed712a1b55045",
            "alt": "",
            "price": { "minor": 0, "major": 12 },
            "variationId": "55fd2d300a85b0ff7af2d165",
            "weight": { "unit": "kg", "value": 1.3 },
            "categories": ["Lamb"],
            "pricePerKilo": { "major": 9, "minor": 23 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d163",
            "name": "South Leicestershire Lamb Shoulder (Whole)",
            "description": "South Leicestershire Lamb",
            "imageId": "55eed9c3672ed712a1b55046",
            "alt": "",
            "price": { "minor": 0, "major": 24 },
            "variationId": "55fd2d300a85b0ff7af2d164",
            "weight": { "unit": "kg", "value": 2.6 },
            "categories": ["Lamb"],
            "pricePerKilo": { "major": 9, "minor": 23 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d166",
            "name": "South Leicestershire Barnsley Lamb Chops (1kg)",
            "description": "South Leicestershire Lamb",
            "imageId": "55eed9a5672ed712a1b5503b",
            "alt": "",
            "price": { "minor": 99, "major": 14 },
            "variationId": "55fd2d300a85b0ff7af2d167",
            "weight": { "unit": "kg", "value": 1 },
            "categories": ["Lamb"],
            "pricePerKilo": { "major": 14, "minor": 99 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d168",
            "name": "South Leicestershire 8 Bone French Trim Lamb Rack (1kg)",
            "description": "South Leicestershire Lamb",
            "imageId": "55fd316b0a85b0ff7af2d19b",
            "alt": "",
            "price": { "minor": 99, "major": 16 },
            "variationId": "55fd2d300a85b0ff7af2d169",
            "weight": { "unit": "kg", "value": 1 },
            "categories": ["Lamb"],
            "pricePerKilo": { "major": 16, "minor": 99 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d16a",
            "name": "South Leicestershire Noisettes Boneless (720g)",
            "description": "South Leicestershire Lamb",
            "imageId": "55eed9bb672ed712a1b55043",
            "alt": "",
            "price": { "minor": 99, "major": 15 },
            "variationId": "55fd2d300a85b0ff7af2d16b",
            "weight": { "unit": "g", "value": 720 },
            "categories": ["Lamb"],
            "pricePerKilo": { "major": 22, "minor": 20 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d16c",
            "name": "South Leicestershire Diced Lamb Shoulder (1kg)",
            "description": "South Leicestershire Lamb",
            "imageId": "55eed9b9672ed712a1b55042",
            "alt": "",
            "price": { "minor": 99, "major": 12 },
            "variationId": "55fd2d300a85b0ff7af2d16d",
            "weight": { "unit": "kg", "value": 1 },
            "categories": ["Lamb"],
            "pricePerKilo": { "major": 12, "minor": 99 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d16e",
            "name": "Gammon Steak (1kg)",
            "description": "Gammon Steak",
            "imageId": "55eed9b4672ed712a1b55041",
            "alt": "",
            "price": { "minor": 99, "major": 7 },
            "variationId": "55fd2d300a85b0ff7af2d16f",
            "weight": { "unit": "kg", "value": 1 },
            "categories": ["Pork"],
            "pricePerKilo": { "major": 7, "minor": 99 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d170",
            "name": "Smoked Whole Gammon (5kg)",
            "description": "Smoked Whole Gammon",
            "imageId": "5648b85a1629541c11f1aba7",
            "alt": "",
            "price": { "minor": 95, "major": 34 },
            "variationId": "55fd2d300a85b0ff7af2d171",
            "weight": { "unit": "kg", "value": 5 },
            "categories": ["Pork"],
            "pricePerKilo": { "major": 6, "minor": 99 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d172",
            "name": "Dry Cured Smoked Back Bacon (500g)",
            "description": "Dry Cured Smoked Back Bacon",
            "imageId": "55eed9dd672ed712a1b5504c",
            "alt": "",
            "price": { "minor": 99, "major": 6 },
            "variationId": "55fd2d300a85b0ff7af2d173",
            "weight": { "unit": "g", "value": 500 },
            "categories": ["Pork"],
            "pricePerKilo": { "major": 13, "minor": 98 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d174",
            "name": "Dry Cured Plain Back Bacon (500g)",
            "description": "Dry Cured Plain Back Bacon",
            "imageId": "55eed9d1672ed712a1b55049",
            "alt": "",
            "price": { "minor": 99, "major": 5 },
            "variationId": "55fd2d300a85b0ff7af2d175",
            "weight": { "unit": "g", "value": 500 },
            "categories": ["Pork"],
            "pricePerKilo": { "major": 11, "minor": 98 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d176",
            "name": "Packington free range Pork Chop (1kg)",
            "description": "Packington free range Pork",
            "imageId": "55eed997672ed712a1b55036",
            "alt": "",
            "price": { "minor": 99, "major": 8 },
            "variationId": "55fd2d300a85b0ff7af2d177",
            "weight": { "unit": "kg", "value": 1 },
            "categories": ["Pork"],
            "pricePerKilo": { "major": 8, "minor": 99 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d178",
            "name": "Packington free range Pork Boneless Loin (2kg)",
            "description": "Packington free range Pork",
            "imageId": "55eed995672ed712a1b55035",
            "alt": "",
            "price": { "minor": 98, "major": 21 },
            "variationId": "55fd2d300a85b0ff7af2d179",
            "weight": { "unit": "kg", "value": 2 },
            "categories": ["Pork"],
            "pricePerKilo": { "major": 10, "minor": 99 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d17a",
            "name": "Packington free range Pork Leg (2kg)",
            "description": "Packington free range Pork",
            "imageId": "55eed999672ed712a1b55037",
            "alt": "",
            "price": { "minor": 98, "major": 13 },
            "variationId": "55fd2d300a85b0ff7af2d17b",
            "weight": { "unit": "kg", "value": 2 },
            "categories": ["Pork"],
            "pricePerKilo": { "major": 6, "minor": 99 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d17c",
            "name": "Packington free range Pork Shoulder (2kg)",
            "description": "Packington free range Pork",
            "imageId": "55fd32720a85b0ff7af2d19c",
            "alt": "",
            "price": { "major": 13, "minor": 99 },
            "variationId": "55fd2d300a85b0ff7af2d17d",
            "weight": { "value": 2, "unit": "kg" },
            "categories": ["Pork"],
            "pricePerKilo": { "major": 6, "minor": 99 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d17e",
            "name": "Packington free range Pork Belly (1kg)",
            "description": "Packington free range Pork",
            "imageId": "55eed993672ed712a1b55034",
            "alt": "",
            "price": { "minor": 99, "major": 5 },
            "variationId": "55fd2d300a85b0ff7af2d17f",
            "weight": { "unit": "kg", "value": 1 },
            "categories": ["Pork"],
            "pricePerKilo": { "major": 5, "minor": 99 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d180",
            "name": "Packington free range Pork Steaks (1kg)",
            "description": "Packington free range Pork",
            "imageId": "55eed99e672ed712a1b55038",
            "alt": "",
            "price": { "minor": 99, "major": 8 },
            "variationId": "55fd2d300a85b0ff7af2d181",
            "weight": { "unit": "kg", "value": 1 },
            "categories": ["Pork"],
            "pricePerKilo": { "major": 8, "minor": 99 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d182",
            "name": "Homemade Beef Burger (Pack of 6)",
            "description": "Six 6oz burgers.  Homemade in store.  Caramelised onion and cracked black pepper.",
            "imageId": "55eed975672ed712a1b5502c",
            "alt": "",
            "price": { "minor": 50, "major": 7 },
            "variationId": "55fd2d300a85b0ff7af2d183",
            "weight": { "unit": "kg", "value": 1 },
            "categories": ["Beef"],
            "pricePerKilo": { "major": 7, "minor": 50 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d184",
            "name": "Homemade Peppercorn Stuffed Beef Burger (Pack of 6)",
            "description": "6x 6oz burgers.  Homemade in store.  Beef Burger with stuffed peppercorn sauce.",
            "imageId": "55eed975672ed712a1b5502c",
            "alt": "",
            "price": { "minor": 50, "major": 10 },
            "variationId": "55fd2d300a85b0ff7af2d185",
            "weight": { "unit": "kg", "value": 1 },
            "categories": ["Beef"],
            "pricePerKilo": { "major": 10, "minor": 50 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d186",
            "name": "Homemade Stuffed Beef Truffles (Pack of 2)",
            "description": "2x 250g.  Homemade in store.  With mushroom sauce.",
            "imageId": "55fd32ce0a85b0ff7af2d19d",
            "alt": "",
            "price": { "minor": 50, "major": 7 },
            "variationId": "55fd2d300a85b0ff7af2d187",
            "weight": { "unit": "g", "value": 500 },
            "categories": ["Beef"],
            "pricePerKilo": { "major": 15, "minor": 0 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d188",
            "name": "Smoked Streaky Bacon (Pack of 16)",
            "description": "Pack of 16. Smoked Streaky Bacon.",
            "imageId": "55eed9df672ed712a1b5504d",
            "alt": "",
            "price": { "minor": 99, "major": 4 },
            "variationId": "55fd2d300a85b0ff7af2d189",
            "weight": { "unit": "g", "value": 500 },
            "categories": ["Pork"],
            "pricePerKilo": { "major": 9, "minor": 98 }
        },
        {
            "productId": "55fd2d300a85b0ff7af2d18a",
            "name": "Plain Streaky Bacon (Pack of 16)",
            "description": "Pack of 16. Unsmoked Streaky Bacon.",
            "imageId": "55eed9a2672ed712a1b5503a",
            "alt": "",
            "price": { "minor": 99, "major": 4 },
            "variationId": "55fd2d300a85b0ff7af2d18b",
            "weight": { "unit": "g", "value": 500 },
            "categories": ["Pork"],
            "pricePerKilo": { "major": 9, "minor": 98 }
        },
        {
            "productId": "55fd54db0a85b0ff7af2d20d",
            "name": "South Leicestershire Flat Iron Steak (1kg)",
            "description": "Flat Iron Steak",
            "imageId": "55eed9a7672ed712a1b5503c",
            "price": { "major": 10, "minor": 99 },
            "variationId": "55fd54ee0a85b0ff7af2d20e",
            "weight": { "unit": "kg", "value": 1 },
            "categories": ["Beef"],
            "pricePerKilo": { "major": 10, "minor": 99 }
        },
        {
            "productId": "55fd552c0a85b0ff7af2d20f",
            "name": "Homemade Ranieri sausages (500g)",
            "description": "Garlic, fennel, chilli and a hint of Champions League!",
            "imageId": "55eed97c672ed712a1b5502f",
            "price": { "major": 5, "minor": 49 },
            "variationId": "55fd553c0a85b0ff7af2d210",
            "weight": { "unit": "g", "value": 500 },
            "categories": ["Pork"],
            "pricePerKilo": { "major": 10, "minor": 98 }
        },
        {
            "productId": "55fd555f0a85b0ff7af2d211",
            "name": "Bone in Venison Haunch (1kg)",
            "description": "Bone in Venison Haunch",
            "imageId": "55eed968672ed712a1b55028",
            "price": { "major": 12, "minor": 99 },
            "variationId": "55fd55820a85b0ff7af2d212",
            "weight": { "unit": "kg", "value": 1 },
            "categories": ["Game"],
            "pricePerKilo": { "major": 12, "minor": 99 }
        },
        {
            "productId": "563bc578d5e0edaf8a5e5bfe",
            "name": "Copas Free Range  Bronze Turkey (Please call to order)",
            "description": "Treat yourself the finest turkey in the land !",
            "imageId": "563bc59ad5e0edaf8a5e5bff",
            "alt": "please call to order!",
            "price": { "major": 0, "minor": 0 },
            "variationId": "563bc60fd5e0edaf8a5e5c00",
            "weight": { "unit": "g", "value": 0 },
            "categories": ["Christmas"],
            "pricePerKilo": { "major": 0, "minor": 0 }
        },
        {
            "productId": "5640fea6d5e0edaf8a5e5c24",
            "name": "Packington free range cockerel (please call to order)",
            "description": "Packington free range cockerel",
            "imageId": "5640f9d5d5e0edaf8a5e5c16",
            "price": { "major": 0, "minor": 0 },
            "variationId": "56410106d5e0edaf8a5e5c2e",
            "weight": { "unit": "g", "value": 0 },
            "categories": ["Christmas"],
            "pricePerKilo": { "major": 0, "minor": 0 }
        },
        {
            "productId": "563d1f67d5e0edaf8a5e5c03",
            "name": "Meat feast hamper (10kg)",
            "description":
                "A carnivores delight! Included in this hamper:  2.5kg Chicken Fillet, 2.5kg Steak Mince, 1kg Pork Steak, 1kg Rump Steak, 1kg Lamb Rump, 1kg Turkey Mince and 1kg of Gourmet Burgers.",
            "detailedDescription":
                "A carnivores delight! Included in this hamper: \n2.5kg Chicken Fillet, 2.5kg Steak Mince, 1kg Pork Steak, 1kg Rump Steak, 1kg Lamb Rump, 1kg Turkey Mince and 1kg of Gourmet Burgers.",
            "imageId": "563d1fa0d5e0edaf8a5e5c04",
            "price": { "major": 70, "minor": 0 },
            "variationId": "563d2114d5e0edaf8a5e5c05",
            "weight": { "unit": "kg", "value": 10 },
            "categories": ["Bulk"],
            "pricePerKilo": { "major": 7, "minor": 0 }
        },
        {
            "productId": "55fd3e8f0a85b0ff7af2d1a0",
            "name": "Boërewors (1kg)",
            "description": "Home made Boërewors",
            "detailedDescription":
                "Made to our own perfected recipe .Our wors is made from beef and pork and is packed full of meat, coupled with a delicate blend of spices and roasted coriander.  A real carnivores delight !",
            "imageId": "5630bf8cc8a7b8879a095a17",
            "price": { "major": 9, "minor": 90 },
            "variationId": "55fd3ea50a85b0ff7af2d1a1",
            "weight": { "unit": "kg", "value": 1 },
            "categories": ["Beef", "South African"],
            "isSpeciality": true,
            "pricePerKilo": { "major": 9, "minor": 90 }
        }
    ];

    constructor(
        private readonly http: HttpClient,
        @Inject("SERVER_URL") private readonly serverUrl: string,
    ) {
    }

    getProducts = (): Observable<Array<Product>> =>
        new Observable(observer => {
            const products = new Array<Product>();

            if (Array.isArray(this.products)) {
                this.products.forEach(json => products.push(new Product(json)));
            }

            observer.next(products);
            observer.complete();
        });

    getRandomProduct = (): Observable<Product> => this.http
        .get(this.serverUrl + this.path + "/random")
        .map(response => new Product(response));

    getSpecialityProducts = (): Observable<Array<Product>> =>
        new Observable(observer => {
            const products = new Array<Product>();

            if (Array.isArray(this.products)) {
                this.products.forEach(json => {
                    const product = new Product(json);
                    if (product.isSpeciality) {
                        products.push(product);
                    }
                });
            }

            observer.next(products);
            observer.complete();
        });
}
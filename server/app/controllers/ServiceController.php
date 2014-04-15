<?php

class ServiceController extends BaseController {
    
    //retrieve a product from database
    
    public function retrieveProduct()
    {
        //@barcode: string contains bar code of the product to be retrieved
        $barcode = Input::get("barcode");
        
        $products = Product::where("barcode", "=", "$barcode");
        
        //return var_dump($products->first()->toArray());
        if ($products->count())
        {
            $product = $products->first()->toArray();
            
            $response = array(
                "success" => 1,
                "product" => $product
            );
        }
        else
        {
            $response = array(
                "success" => 0,
                "message" => "No Product with the given barcode $barcode"
            );
        }
        
        return Response::json($response);
        
        
    }
    
    //retrieve all categories from database
    public function retrieveCategories()
    {   
        //get all categories as array
        $categories = Category::all();
        
        //response json 
        $response = array();
        
        foreach ($categories as $category)
        {   
            array_push($response, array(
                "categoryID" => $category->id,
                "categoryName" => $category->name,
                "products" => $category->products->toArray()
            ));
            
        }
        
        return Response::json($response);
        
    }
    
    //create new product
    public function createProduct()
    {
        
        $product = new Product();
        $product->name = Input::get("name");
        $product->barcode = Input::get("barcode");
        $product->price = Input::get("price");
        $product->category_id = Input::get("category_id");
        
        $product->save();
    }


    public function getForm()
    {
        return View::make("form");
    }
    
    public function retrieveMarket()
    {
        $latitude = Input::has("latitude") ? Input::get("latitude") : 0;
        $longitude = Input::has("longitude") ? Input::get("longitude") : 0;
        
        //approximate the location
        $latitude = round($latitude * 10000) / 10000;
        $longitude = round($longitude * 10000) / 10000;
        
        
        
        $locations = Location::where("latitude", "=", $latitude)
                    ->where("longitude", "=", $longitude);
        
        
        
        if ($locations->count())
        {
            $location = $locations->first();
            
            $market = Market::where("location_id", "=", $location->id)->first()->toArray();
            
            
            $response = array(
                "success" => 1,
                "market" => $market
            );
        }
        else
        {
            $response = array(
                "success" => 0,
                "message" => "No Market with the given location (latitude = $latitude, longitude = $longitude)"
            );
        }
        
        return Response::json($response);
        
        
    }

}
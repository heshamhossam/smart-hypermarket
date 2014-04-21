<?php

class ServiceController extends BaseController {
    
    //retrieve a product from database
    
    public function retrieveProduct()
    {
        //@barcode: string contains bar code of the product to be retrieved
        $key = "barcode";
        $value = 0;
        
        if (Input::has("barcode"))
            $key = "barcode";
        else if (Input::has("id"))
            $key = "id";
        
        $value = Input::get($key);
        
        
        
        $products = Product::where("$key", "=", "$value");
        
        
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
                "message" => "No Product with the given $key $value"
            );
        }
        
        return Response::json($response);
        
        
    }
    
    //retrieve all categories from database
    public function retrieveCategories()
    {   
        if (Input::has("market_id"))
            $marketId = Input::get("market_id");
        else
            return Response::json(array("success" => 0, "message" => "No Market with the market id"));
        
        $market = Market::find($marketId);
        //response json 
        $response = array();
        
        foreach ($market->categories as $category)
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
        
        $product->save();
        
        //save the product in the category
        DB::table('category_product')->insert(
            array('category_id' => Input::get("category_id"), 'product_id' => $product->id)
        );
        
        //save the product in the market
        DB::table('market_product')->insert(
            array('market_id' => Input::get("market_id"), 'product_id' => $product->id, "price" => Input::get("price"))
        );
    }
    
    public function editProduct()
    {
        $product_id = Input::get("id");
        
        $product = Product::find($product_id);
        $product->name = Input::get("name");
        $product->barcode = Input::get("barcode");
        $product->save();
        
        DB::table('market_product')
            ->where('product_id', $product_id)
            ->where('market_id', Input::get("market_id"))
            ->update(array('price' => Input::get("price")));
        
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
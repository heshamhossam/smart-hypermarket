<?php

/**
 * Description of MarketController
 *
 * @author Hesham
 */
class MarketController extends BaseController {
    
    public function retrieve()
    {
        $latitude = Input::has("latitude") ? Input::get("latitude") : 0;
        $longitude = Input::has("longitude") ? Input::get("longitude") : 0;
        
        //approximate the location
        $latitude = round($latitude * 10000) / 10000;
        $longitude = round($longitude * 10000) / 10000;
        
        
        
//        $locations = Location::where("latitude", "=", $latitude)
//                    ->where("longitude", "=", $longitude);
        
        $locations = Location::all();
        
        
        
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
            foreach($category->products as $product)
            {
                $p = DB::table('market_product')
                    ->where('market_id', "=", Input::get("market_id"))
                    ->where('product_id', "=", $product->id);
                
                if ($p->count())
                    $product->price = $p->first()->price;
            }
            
            array_push($response, array(
                "categoryID" => $category->id,
                "categoryName" => $category->name,
                "products" => $category->products->toArray()
            ));
            
        }
        
        return Response::json($response);
        
    }
    
}

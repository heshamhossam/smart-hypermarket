<?php

class Product extends Eloquent {
    //string contains the name of table in the database
    protected $table = "products";

    //array of fields which can be filled
    protected $fillable = array("name", "barcode");
    
    public static function retrieve($market, $uniqueKeyValueArray)
    {
        //extract the kay and value
        foreach ($uniqueKeyValueArray as $k => $v) {
            $key = $k;
            $value = $v;
        }
        
        $products = Product::where("$key", "=", "$value");
        
        if ($products->count())
        {
            $product = $products->first();
            
            $p = DB::table('market_product')
                        ->where('market_id', "=", $market->id)
                        ->where('product_id', "=", $product->id);
                
            if ($p->count())
                $product->price = $p->first()->price;
            else
                $product->price = 0;
            
            return $product;
        }
        
        return NULL;
    }
     
    
    public static function deleteMe($productId, $market = NULL)
    {
        if ($market)
        {
            $products = $market->products()->where("product_id", "=", "$productId");
            if ($products->count())
            {
                $products->first()->forceDelete();
                return true;
            }
        }
        else 
        {
            $product = Product::find($productId);
            if ($product)
            {
                $product->forceDelete();
                return true;
            }
        }
        
        return false;
    }
        
        
}
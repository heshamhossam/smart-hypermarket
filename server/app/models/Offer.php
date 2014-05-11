<?php

class Offer extends Eloquent {
    
    //string contains the name of table in the database
    protected $table = "offers";

    //array of fields which can be filled
    protected $fillable = array("name", "price", "teaser", "market_id");
    
    public function products()
    {
        return $this->belongsToMany("Product");
    }
    
    public function getProducts()
    {
        $products = $this->products;
        foreach ($products as $product) {
            
            $p = DB::table('offer_product')
                        ->where('offer_id', "=", $this->id)
                        ->where('product_id', "=", $product->id);
            
            if ($p->count())
                $product->quantity = $p->first()->product_quantity;
            else
                $product->quantity = 0;
            
        }
        
        return $products;
        
    }
    
    
    
        
}
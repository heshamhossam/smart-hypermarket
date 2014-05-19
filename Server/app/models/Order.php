<?php


/**
 * Description of Order
 *
 * @author Hesham
 */
class Order extends Eloquent {
    //string contains the name of table in the database
    protected $table = "orders";

    //array of fields which can be filled
    protected $fillable = array("state", "market_id", "user_id", "confirmation_code");
    
    const WAITING = "WAITING";
    const PREPARING = "PREPARING";
    const READY = "READY";
    const DONE = "DONE";
    const ALL = "ALL";
    
    //products in this category
    public function products() {
        return $this->belongsToMany("Product");
    }
    
    public function getProducts(Market $market)
    {
        $fullProducts = array();
        $i = 0;
        foreach($this->products as $product)
        {
            $marketProduct = $market->findProduct(array("id" => $product->id));
            
            $orderProduct = DB::table('order_product')
                        ->where('order_id', "=", $this->id)
                        ->where('product_id', "=", $product->id);
            
            
            if ($orderProduct->count())
                $marketProduct->quantity = $orderProduct->first()->quantity;
            else
                $marketProduct->quantity = 0;
            
            $fullProducts[$i] = $marketProduct->toArray();
            $i++;
        }
        
        return $fullProducts;
    }
    
    public function user()
    {
        return $this->hasOne("User");
    }
    
    
}

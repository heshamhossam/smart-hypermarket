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
    
    public function user()
    {
        return $this->hasOne("User");
    }
    
    
}

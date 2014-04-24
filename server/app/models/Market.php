<?php

class Market extends Eloquent {
	//string contains the name of table in the database
	protected $table = "markets";
	
	//array of fields which can be filled
	protected $fillable = array("name", "location_id");
	
	//location
        public function location()
        {
            return $this->hasOne(Location);
        }
        
        //products in this market
	public function products() {
            return $this->belongsToMany("Product");
	}
        
        //categories in this market
        public function categories()
        {
            return $this->belongsToMany("Category");
        }
        
        
        public function findProduct($uniqueKeyValueArray)
        {
            return Product::retrieve($this, $uniqueKeyValueArray);
        }
        
        public function deleteProduct($productId)
        {
            return Product::deleteMe($productId, $this);
        }
	
		
}
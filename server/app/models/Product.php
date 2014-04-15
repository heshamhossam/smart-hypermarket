<?php

class Product extends Eloquent {
	//string contains the name of table in the database
	protected $table = "products";
	
	//array of fields which can be filled
	protected $fillable = array("name", "barcode", "price", "category_id");
        
        
        
}
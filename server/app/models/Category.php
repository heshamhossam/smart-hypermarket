<?php

class Category extends Eloquent {
	//string contains the name of table in the database
	protected $table = "categories";
	
	//array of fields which can be filled
	protected $fillable = array("name");
	
	//products in this category
	public function products() {
		return $this->hasMany("Product");
	}
	
		
}
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
	
		
}
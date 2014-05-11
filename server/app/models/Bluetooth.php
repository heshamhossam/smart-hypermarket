<?php

/**
 * Description of Review
 *
 * @author Hesham
 */
class Bluetooth extends Eloquent {
    //string contains the name of table in the database
    protected $table = "bluetooths";

    //array of fields which can be filled
    protected $fillable = array("name", "address", "category_id");
    
}

<?php

/**
 * Description of Review
 *
 * @author Hesham
 */
class Review extends Eloquent {
    //string contains the name of table in the database
    protected $table = "reviews";

    //array of fields which can be filled
    protected $fillable = array("body", "product_id", "user_id");
    
    public function user()
    {
        return $this->belongsTo("User");
    }
}

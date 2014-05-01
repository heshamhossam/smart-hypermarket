<?php

class Category extends Eloquent {
	//string contains the name of table in the database
	protected $table = "categories";
	
	//array of fields which can be filled
	protected $fillable = array("name", "category_id");
	
	//products in this category
	public function products() {
		return $this->belongsToMany("Product");
	}
        
        public function addProduct($product)
        {
            //save the product in the category
            return DB::table('category_product')->insert(
                    array('category_id' => $this->id, 'product_id' => $product->id)
                );
        }
        
        public function getProducts($market)
        {
            $categoryProducts = $this->products;

            $marketProducts = array();
            
            foreach ($categoryProducts as $categoryProduct)
            {
                $p = DB::table('market_product')
                        ->where('market_id', "=", $market->id)
                        ->where('product_id', "=", $categoryProduct->id);
                
                if ($p->count())
                    $marketProducts[] = $market->findProduct(array("id" => $p->first()->product_id))->toArray();
            }

            return $marketProducts;

        }
	
		
}
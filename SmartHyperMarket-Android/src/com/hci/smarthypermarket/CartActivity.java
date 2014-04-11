package com.hci.smarthypermarket;

import android.annotation.SuppressLint;
import android.annotation.TargetApi;
import android.app.ActionBar;
import android.app.Activity;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.os.Build;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.widget.ListView;

@SuppressLint("NewApi")
public class CartActivity extends Activity implements ICartActivity {
	
	public static Shopper shopper = null;

	@TargetApi(Build.VERSION_CODES.HONEYCOMB)
	@SuppressLint("NewApi")
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		//set action bar
		ActionBar ab = getActionBar(); 
        ColorDrawable colorDrawable = new ColorDrawable(Color.rgb(10, 73, 88));     
        ab.setBackgroundDrawable(colorDrawable);
        ab.setDisplayShowHomeEnabled(false);
        
        
        
		
        if (shopper == null)
        	shopper = new Shopper();
		
		
		/*
		shopper.getOrder().getProducts().add(new Product("2", "Shweps", "456", 30, "1"));
		shopper.getOrder().getProducts().add(new Product("3", "Chips", "789", 10, "2"));	
		*/
		shopper.getOrder().showProductsItems(CartActivity.this, (ListView) findViewById(R.id.listViewProducts));
		
		
		//startProductActivity();
		
		
		//start the product activity and send the shopper in the intent
		//startProductActivity(shopper);
		
		
	}
	
	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		MenuInflater mif = getMenuInflater();
		mif.inflate(R.menu.main, menu);
		return super.onCreateOptionsMenu(menu);
	}
	
	@Override
	public boolean onOptionsItemSelected(MenuItem item){
		switch(item.getItemId()){
		case R.id.camera_icon:
			startBarCodeActivity();
			return true;
		default:
			return super.onOptionsItemSelected(item);
		}
	}

	@Override
	public void startBarCodeActivity() {
		// TODO Auto-generated method stub
		Intent intent = new Intent(CartActivity.this, BarCodeActivity.class);
		startActivity(intent);
		
	}


}

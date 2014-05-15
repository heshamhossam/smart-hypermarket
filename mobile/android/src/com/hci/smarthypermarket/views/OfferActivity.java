package com.hci.smarthypermarket.views;

import com.hci.smarthypermarket.R;
import com.hci.smarthypermarket.models.Offer;
import com.hci.smarthypermarket.models.Product;

import android.os.Bundle;
import android.app.ActionBar;
import android.app.Activity;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.view.Menu;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;

public class OfferActivity extends Activity {
	
	private TextView textViewOfferName = null;
	private TextView textViewOfferPrice = null;
	private TextView textViewOfferTeaser = null;
	private ListView listViewOfferProducts = null;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_offer);
		
		ActionBar ab = getActionBar(); 
        ColorDrawable colorDrawable = new ColorDrawable(Color.rgb(10, 73, 88));     
        ab.setBackgroundDrawable(colorDrawable);
       
        ab.setDisplayShowHomeEnabled(false);
        
        textViewOfferName = (TextView) findViewById(R.id.offerName);
        textViewOfferPrice = (TextView) findViewById(R.id.offerPrice);
        textViewOfferTeaser = (TextView) findViewById(R.id.offerTeaser);
        listViewOfferProducts = (ListView) findViewById(R.id.listViewOfferProducts);
        
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.offer, menu);
		return true;
	}

	public void showOffer(Offer offer){
		textViewOfferName.setText(offer.getName());
		textViewOfferPrice.setText(offer.getPrice());
		textViewOfferTeaser.setText(offer.getTeaser());
		
		ArrayAdapter<Product> adapter = new CartListAdapter(this, offer.getProducts());
		listViewOfferProducts.setAdapter(adapter);
	}
}

package com.hci.smarthypermarket.views;


import java.util.ArrayList;
import java.util.List;

import com.hci.smarthypermarket.R;
import com.hci.smarthypermarket.models.Bluetooth;
import com.hci.smarthypermarket.models.Category;
import com.hci.smarthypermarket.models.Offer;
import com.hci.smarthypermarket.models.Product;

import android.os.Bundle;
import android.app.ActionBar;
import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.SeekBar;
import android.widget.TextView;
import android.widget.Toast;
import android.widget.SeekBar.OnSeekBarChangeListener;

public class OfferActivity extends Activity {
	
	private TextView textViewOfferName = null;
	private TextView textViewOfferPrice = null;
	private TextView textViewOfferTeaser = null;
	private ListView listViewOfferProducts = null;
	private Button AddOfferButton = null;
	
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
        AddOfferButton = (Button) findViewById(R.id.addOfferButton);
        
        AddOfferButton.setOnClickListener(new OnClickListener(){
        	public void onClick(View v){
        		showInputNumberPopup();
        	}
        });
        
        Category categoryBooks = new Category("5", "Books");
		categoryBooks.setBluetooth(new Bluetooth("Books", "Books", 0));
		categoryBooks.getProducts().add(new Product("28", "Medical Imaging", "0819436232", (float) 80, "400", "this is a CS Book"));
		categoryBooks.getProducts().add(new Product("29", "Digital Image Processing", "9780982085400", (float) 87, "982", " a CS Book related to image manipulations"));
		categoryBooks.setOffer(new Offer("Never Stop Reading", "120", "Buy Medical Imaging book and take Digital Image Processing Book for free, Hurry up now before It's out of stock", "5-7-1993", "5-7-2014", categoryBooks.getProducts()));
        
		showOffer(categoryBooks.getOffer());
        
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
		
		
		ArrayAdapter<IShowableItem> adapter = new CartListAdapter(this, offer.getShowableItems());
		listViewOfferProducts.setAdapter(adapter);
	}
	
	public void showInputNumberPopup() {
		  // TODO Auto-generated method stub
		  final AlertDialog.Builder alertdlg = new AlertDialog.Builder(this);
		  alertdlg.setTitle("Quantity");
		  alertdlg.setMessage("Pick up the Quantity!");
		  
		  LinearLayout linear = new LinearLayout(this);
		  linear.setOrientation(1);
		  
		  SeekBar seekBar = new SeekBar(this);
		  seekBar.setMax(10);
		  final TextView seekBarResult = new TextView(this);
		  
		  seekBarResult.setText(seekBar.getProgress() + "/" + seekBar.getMax());
		        seekBar.setOnSeekBarChangeListener(new OnSeekBarChangeListener(){
		         public void onProgressChanged(SeekBar seekbar, int ProgressValue, boolean fromUser){

		         }
		         @Override
		            public void onStartTrackingTouch(SeekBar seekBar){
		          
		         }
		         @Override
		            public void onStopTrackingTouch(SeekBar seekBar){

		         }
		        });
		        
		        linear.addView(seekBar);
		        linear.addView(seekBarResult);
		        
		        alertdlg.setView(linear);
		        
		        alertdlg.setPositiveButton("Add", new DialogInterface.OnClickListener() {
		   
		   @Override
		   public void onClick(DialogInterface dialog, int which) {

		   }
		  });
		        alertdlg.setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
		   
		   @Override
		   public void onClick(DialogInterface dialog, int which) {
		    // TODO Auto-generated method stub
		    Toast.makeText(getApplicationContext(), "Cancel Pressed", Toast.LENGTH_LONG).show();
		    finish();
		   }
		  });
		        
		  AlertDialog alertDialog = alertdlg.create();
		  alertDialog.show();
		  }
}

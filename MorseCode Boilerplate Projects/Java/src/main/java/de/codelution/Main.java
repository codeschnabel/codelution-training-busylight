package de.codelution;

import java.util.List;

import de.codelution.morseadapter.LightMorseAdapter;
import de.codelution.morseadapter.contracts.Dah;
import de.codelution.morseadapter.contracts.Dit;
import de.codelution.morseadapter.contracts.Pause;

public class Main {
    public static void main(String[] args) {
        
        var morseAdapter = new LightMorseAdapter();

        // add your integration code here

        morseAdapter.morse(
            List.of(
                // S
                new Dit(), new Pause(), 
                new Dit(), new Pause(), 
                new Dit(), new Pause(), 
                //
                new Pause(), new Pause(), new Pause(),
                // O
                new Dah(), new Pause(), 
                new Dah(), new Pause(), 
                new Dah(), new Pause(),
                // 
                new Pause(), new Pause(), new Pause(),
                // S
                new Dit(), new Pause(), 
                new Dit(), new Pause(), 
                new Dit(), new Pause()
            ));
    }
}
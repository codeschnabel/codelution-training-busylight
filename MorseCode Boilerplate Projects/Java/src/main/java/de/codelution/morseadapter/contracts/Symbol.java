package de.codelution.morseadapter.contracts;

import com.google.gson.Gson;

public abstract class Symbol {
    
    private int timeInMilliseconds;
    private int red;
    private int green;
    private int blue;

    public static int DIT_LENGTH_IN_MILLISECONDS = 100;

    protected Symbol(int getTimeInMilliseconds, int red, int green, int blue){
        this.timeInMilliseconds = getTimeInMilliseconds;
        this.red = red;
        this.green = green;
        this.blue = blue;
    }

    public int getTimeInMilliseconds(){
        return timeInMilliseconds;
    }
    
    public int getRed(){
        return red;
    }

    public int getGreen(){
        return green;
    }

    public int getBlue(){
        return blue;
    }

    @Override
    public boolean equals(Object obj) {
        if (!(obj instanceof Symbol)) return false;
        if (obj == this) return true;

        var otherSymbol = (Symbol) obj;
        
        // 1. Möglichkeit: Properties im Detail vergleichen
        return 
            otherSymbol.getTimeInMilliseconds() == this.getTimeInMilliseconds()
            && otherSymbol.getRed() == this.getRed()
            && otherSymbol.getGreen() == this.getGreen()
            && otherSymbol.getBlue() == this.getBlue();

        // 2. Möglichkeit: JSON-Strings vergleichen
        // var jsonOfThis = new Gson().toJson(this);
        // var jsonOfObj = new Gson().toJson(obj);
        // return jsonOfThis.equals(jsonOfObj);

        // 3. Möglichkeit: lombok Library verwenden
        // -> liefert Attribute für Auto-Generierung von equals, hashCode, toString
    }
}
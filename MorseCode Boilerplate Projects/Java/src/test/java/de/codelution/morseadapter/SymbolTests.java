package de.codelution.morseadapter;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.assertj.core.api.Assertions.assertThat;

import org.junit.jupiter.api.Test;

import de.codelution.morseadapter.contracts.Dah;
import de.codelution.morseadapter.contracts.Dit;
import de.codelution.morseadapter.contracts.Pause;

public class SymbolTests {
    
    @Test
    public void testEquality() {
        // 1. Equals Methode in den Symbol Klassen implementieren
        assertEquals(new Dit(), new Dit());
        assertEquals(new Dah(), new Dah());
        assertEquals(new Pause(), new Pause());

        // 2. AssertJ Library verwenden
        assertThat(new Dit()).isEqualTo(new Dit());
    }
}

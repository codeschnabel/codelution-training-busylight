package de.codelution.charactersplit;

import static org.junit.jupiter.api.Assertions.assertTrue;

import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;

import de.codelution.junit.jupiter.extensions.CodelutionTestWatcher;


@ExtendWith(CodelutionTestWatcher.class) // we need to extend every test class like this
public class SomeTestClass1 {

    @Test
    public void Some_Example_Test() {
        assertTrue(false);
    }
}

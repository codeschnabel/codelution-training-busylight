package de.codelution.morseadapter;

import java.io.IOException;
import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse.BodyHandlers;
import java.util.Collection;

import de.codelution.morseadapter.contracts.AMorseAdapter;
import de.codelution.morseadapter.contracts.Symbol;

public class LightMorseAdapter implements AMorseAdapter {

    @Override
    public void morse(Collection<Symbol> symbols) {
        var httpClient = HttpClient.newHttpClient();
        
        for (var symbol : symbols) {
            try {
                var httpRequest = createHttpRequest(symbol);
                httpClient.send(httpRequest, BodyHandlers.ofString());
                Thread.sleep(symbol.getTimeInMilliseconds());
            }
            catch(IOException e) {
                System.out.println("IO EXEPTION in Codelution Test Watcher:");
                System.out.println(e.getMessage());
                e.printStackTrace();
            }
            catch(InterruptedException e) {
                System.out.println("Interrupted EXEPTION in Codelution Test Watcher:");
                System.out.println(e.getMessage());
                e.printStackTrace();
            }
        }
    }

    private HttpRequest createHttpRequest(Symbol symbol) {
        return HttpRequest.newBuilder()
            .GET()
            .uri(URI.create(
                "http://localhost:8989/?action=light&"
                    +"red="+symbol.getRed()
                    +"&green="+symbol.getGreen()
                    +"&blue="+symbol.getBlue()))
            .build();
    }
    
}

package de.codelution.junit.jupiter.extensions;

import java.io.IOException;
import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse.BodyHandlers;
import java.util.Optional;

import org.junit.jupiter.api.extension.ExtensionContext;
import org.junit.jupiter.api.extension.TestWatcher;
import org.junit.jupiter.api.extension.ExtensionContext.Namespace;
import org.junit.jupiter.api.extension.ExtensionContext.Store;

public class CodelutionTestWatcher implements TestWatcher {

    private static String FAILED_TESTS = "failedTests";

    @Override
    public void testAborted(ExtensionContext context, Throwable cause) {
        TestWatcher.super.testAborted(context, cause);
    }

    @Override
    public void testDisabled(ExtensionContext context, Optional<String> reason) {
        TestWatcher.super.testDisabled(context, reason);
    }

    @Override
    public void testFailed(ExtensionContext context, Throwable cause) {
        increaseNumberOfFailedTests(context);
        setBusylight(context);
        TestWatcher.super.testFailed(context, cause);
    }

    @Override
    public void testSuccessful(ExtensionContext context) {
        setBusylight(context);
        TestWatcher.super.testSuccessful(context);
    }

    private void increaseNumberOfFailedTests(ExtensionContext context) {
        var store = this.getRootStore(context);
        var failedTests = store.get(FAILED_TESTS, Integer.class);

        if (failedTests == null)
            store.put(FAILED_TESTS, 1);
        else
            store.put(FAILED_TESTS, failedTests+1);
    }

    private void setBusylight(ExtensionContext context) {
        var store = this.getRootStore(context);
        var failedTests = store.get(FAILED_TESTS, Integer.class);

        var httpClient = HttpClient.newHttpClient();
        var lightsToRedRequest = HttpRequest.newBuilder()
            .GET()
            .uri(URI.create("http://localhost:8989/?action=light&red=255&green=0&blue=0"))
            .build();

        var lightsToGreenRequest = HttpRequest.newBuilder()
            .GET()
            .uri(URI.create("http://localhost:8989/?action=light&red=0&green=255&blue=0"))
            .build();

        try {
            if (failedTests == null || failedTests == 0)
                httpClient.send(lightsToGreenRequest, BodyHandlers.ofString());
            else
                httpClient.send(lightsToRedRequest, BodyHandlers.ofString());
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
   
    private Store getRootStore(ExtensionContext context) {
        return context.getRoot().getStore(Namespace.GLOBAL);
        // return context.getStore(Namespace.create(getClass(), context.getRequiredTestMethod())); // get store local to the test method
    }
}

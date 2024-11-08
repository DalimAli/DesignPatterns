
// Usage:
using Observer.DesignPattern;

Subject subject = new Subject();
ConcreteObserver observer = new ConcreteObserver();
subject.Attach(observer);
subject.Notify(); // Output: Observer has been notified.


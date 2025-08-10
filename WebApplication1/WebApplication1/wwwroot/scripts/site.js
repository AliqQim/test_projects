class A {
    static f() { alert("Aa"); }
    static g() { this.f(); }
}
class B extends A {
    static f() { alert("Bb"); }
}
B.f();
A.f();

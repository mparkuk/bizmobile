import { createWebHistory, createRouter } from "vue-router";
import Home from "@/components/Home.vue";
import Counter from "@/components/Counter.vue";
import MobileData from "@/components/MobilePhones.vue";

const routes = [
    {
        path: "/",
        name: "Home",
        component: Home,
    },
    {
        path: "/Counter",
        name: "Counter",
        component: Counter,
    },
    {
        path: "/MobilePhones",
        name: "MobilePhones",
        component: MobileData,
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;
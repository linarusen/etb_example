<template>
    <div>
        <div class="ma-1">
            <v-card class="mx-auto">
                <v-img class="align-end text-white" height="200" src="https://cdn.vuetifyjs.com/images/cards/docks.jpg"
                    cover>
                    <v-card-title>{{ value.name }}</v-card-title>
                </v-img>
                <v-card-subtitle class="pt-4">
                    {{ value.bDay }}
                </v-card-subtitle>
                <v-card-text>
                    <div> {{ value.email }} </div>
                    <!-- <div>Whitsunday Island, Whitsunday Islands</div> -->
                </v-card-text>
                <v-card-actions>
                    <!-- <v-btn color="orange">
                        Share
                    </v-btn> -->
                    <v-btn color="error" @click="submit">
                        Delete
                    </v-btn>
                </v-card-actions>
            </v-card>
        </div>
    </div>
</template>
<script setup lang="ts">

</script>
<script lang="ts">
import api from '@/store/api/i'
export default {
    props: {
        value: {
            default: () => ({} as any)
        }
    },
    data: () => ({
    }),

    created() {
        //
    },

    methods: {
        async submit() {
            await api.delete('customers', this.value);
            this.$emit('submit');
        },
    },
}
</script>